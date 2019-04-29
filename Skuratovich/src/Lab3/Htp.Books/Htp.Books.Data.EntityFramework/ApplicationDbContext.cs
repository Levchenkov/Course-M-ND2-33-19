using System;
using System.Linq;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Htp.Books.Data.EntityFramework.EntityConfigurations;
using System.Collections.Generic;
using System.IO;

namespace Htp.Books.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        // cd Projects/Course-M-ND2-33-19/Skuratovich/src/Lab3/Htp.Books/Htp.Books.Data.EntityFramework/
        //
        // dotnet ef migrations add InitialCreate
        //
        // dotnet ef database update

        private IHistoryLogHandler<Book> historyLogHandler;

        //TODO: Check ctor ApplicationDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions, IHistoryLogHandler<Book> historyLogHandler) : base(dbContextOptions)
        {
            this.historyLogHandler = historyLogHandler;
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<HistoryLog> HistoryLogs { get; set; }

        public DbSet<BookLanguage> BookLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string wanted_path = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            //optionsBuilder.UseSqlite($"Filename={wanted_path}/BookCatalog.db");

            //optionsBuilder.UseSqlServer(
            //@"Server = localhost, 1433; Database = BookCatalog;"
            //+ "User = SA; Password = $zDkJDCmx8CNcJh");

            //"Server=(localdb)\\mssqllocaldb;Database=Htp.News;Trusted_Connection=True;MultipleActiveResultSets=true"
            //"Server = localhost, 1433; Database = BookCatalog; User = SA; Password = $zDkJDCmx8CNcJh"

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookLanguageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryLogEntityConfiguration());
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var modifiedBooks = this.ChangeTracker.Entries<Book>()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToList();

            modifiedBooks.ForEach(e =>
            {
                var currentBook = (Book)this.Entry(e).CurrentValues.ToObject();
                var originalBook = (Book)this.Entry(e).OriginalValues.ToObject();

                var currentLanguages = this.ChangeTracker.Entries<BookLanguage>()
                           .Where(t => ((t.State == EntityState.Added) || (t.State == EntityState.Modified)) && t.Entity.BookId == currentBook.Id)
                           .Select(t => t.Entity)
                           .ToList();

                currentBook.BookLanguages = new List<BookLanguage>();
                currentLanguages.ForEach(bl =>
                {
                    currentBook.BookLanguages.Add((BookLanguage)this.Entry(bl).CurrentValues.ToObject());
                });

                var originalLanguages = this.ChangeTracker.Entries<BookLanguage>()
                   .Where(t => ((t.State == EntityState.Deleted) || (t.State == EntityState.Modified)) && t.Entity.BookId == currentBook.Id)
                   .Select(t => t.Entity)
                   .ToList();

                originalBook.BookLanguages = new List<BookLanguage>();
                originalLanguages.ForEach(bl =>
                {
                   originalBook.BookLanguages.Add((BookLanguage)this.Entry(bl).OriginalValues.ToObject());
                });

                var currentBookJson = historyLogHandler.Serialize(currentBook);
                var originalBookJson = historyLogHandler.Serialize(originalBook);

                var historyLog = new HistoryLog()
                {
                    Origin = originalBookJson,
                    Actually = currentBookJson,
                    EntityId = e.Id.ToString(),
                    EntityType = e.GetType().ToString(),
                    UpdateTime = DateTime.UtcNow,
                };
                Set<HistoryLog>().Add(historyLog);
            });

            return base.SaveChanges();
        }
    }
}
