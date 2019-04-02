using System;
using System.Linq;
using Htp.Books.Data.Contracts;
using Htp.Books.Data.Contracts.Entities;
using Htp.Books.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Htp.Books.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext 
    {
        // cd Projects/Course-M-ND2-33-19/Skuratovich/src/Lab3/Htp.Books/Htp.Books.Data.EntityFramework/
        //
        // dotnet ef migrations add InitialCreate
        //
        // dotnet ef database update

        public IHistoryLogHandler<Book> historyLogHandler;


        ////TODO: Check ctor ApplicationDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions, IHistoryLogHandler<Book> historyLogHandler) : base(dbContextOptions)
        {
        }

        //////TODO: Check ctor ApplicationDbContext
        //public ApplicationDbContext(IHistoryLogHandler<Book> historyLogHandler)
        //{
        //    this.historyLogHandler = historyLogHandler;
        //}


        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<HistoryLog> HistoryLogs { get; set; }

        public DbSet<BookLanguage> BookLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //@"Server = localhost, 1433; Database = BookCatalog;"
            //+ "User = SA; Password = $zDkJDCmx8CNcJh");

            //"Server=(localdb)\\mssqllocaldb;Database=Htp.News;Trusted_Connection=True;MultipleActiveResultSets=true"
            //"Server = localhost, 1433; Database = BookCatalog; User = SA; Password = $zDkJDCmx8CNcJh"

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bookLanguageConfiguration = modelBuilder.Entity<BookLanguage>();
            bookLanguageConfiguration.HasKey(x => new { x.BookId, x.LanguageId });
            bookLanguageConfiguration.HasOne(x => x.Book).WithMany(x => x.BookLanguages).HasForeignKey(x => x.BookId);
            bookLanguageConfiguration.HasOne(x => x.Language).WithMany(x => x.BookLanguages).HasForeignKey(x => x.LanguageId);
            bookLanguageConfiguration.Ignore(x => x.Id);

            var languageConfiguration = modelBuilder.Entity<Language>();
            languageConfiguration.HasKey(x => x.Id);
            languageConfiguration.Property(x => x.Title).IsRequired();

            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();
            bookConfiguration.Property(x => x.Description).IsRequired();
            bookConfiguration.Property(x => x.Author).IsRequired();
            bookConfiguration.Property(x => x.Created).IsRequired();
            bookConfiguration.Property(x => x.IsPaper).IsRequired();
            bookConfiguration.Property(x => x.DeliveryRequired).IsRequired();
            bookConfiguration.Property(x => x.RowVersion).IsRowVersion().IsRequired();
            bookConfiguration.Ignore(x => x.LongRowVersion);

            //bookConfiguration.HasOne(x => x.Genre).WithMany(x => x.Books).HasForeignKey(x => x.Genre).IsRequired();
            bookConfiguration.HasOne(x => x.Genre).WithMany(x => x.Books);
            bookConfiguration.HasOne(x => x.Genre).WithMany(x => x.Books).HasForeignKey(x => x.GenreId);

            var genreConfiguration = modelBuilder.Entity<Genre>();
            genreConfiguration.HasKey(x => x.Id);
            genreConfiguration.Property(x => x.Title).IsRequired();

            var historyLogConfiguration = modelBuilder.Entity<HistoryLog>();
            historyLogConfiguration.HasKey(x => x.Id);
            historyLogConfiguration.Property(x => x.EntityId).IsRequired();
            historyLogConfiguration.Property(x => x.EntityType).IsRequired();
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var modified = this.ChangeTracker.Entries<Book>()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToList();

            modified.ForEach(e =>
            {
                var currentBook = historyLogHandler.Serialize((Book)this.Entry(e).CurrentValues.ToObject());
                var originalBook = historyLogHandler.Serialize((Book)this.Entry(e).OriginalValues.ToObject());

                var historyLog = new HistoryLog()
                {
                    Origin = originalBook,
                    Actually = currentBook,
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
