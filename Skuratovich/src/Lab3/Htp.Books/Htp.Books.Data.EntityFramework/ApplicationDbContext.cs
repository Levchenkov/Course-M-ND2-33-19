using Htp.Books.Data.Contracts.Entities;
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

        //TODO: Check ctor ApplicationDbContext
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<HistoryLog> HistoryLogs { get; set; }

        public DbSet<BookLanguage> BookLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server = localhost, 1433; Database = BookCatalog;"
                + "User = SA; Password = $zDkJDCmx8CNcJh");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bookLanguageConfiguration = modelBuilder.Entity<BookLanguage>();
            bookLanguageConfiguration.HasKey(x => new { x.BookId, x.LanguageId });
            bookLanguageConfiguration.HasOne(x => x.Book).WithMany(x => x.BookLanguages).HasForeignKey(x => x.BookId);
            bookLanguageConfiguration.HasOne(x => x.Language).WithMany(x => x.BookLanguages).HasForeignKey(x => x.LanguageId);

            var languageConfiguration = modelBuilder.Entity<Language>();
            languageConfiguration.HasKey(x => x.Id);
            languageConfiguration.Property(x => x.Title).IsRequired();

            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();
            bookConfiguration.Property(x => x.RowVersion).IsRowVersion();
            bookConfiguration.Property(x => x.RowVersion).IsRowVersion();
            bookConfiguration.HasOne(x => x.Genre).WithMany(x => x.Books).IsRequired();

            var genreConfiguration = modelBuilder.Entity<Genre>();
            genreConfiguration.HasKey(x => x.Id);
            genreConfiguration.Property(x => x.Title).IsRequired();

            var historyLogConfiguration = modelBuilder.Entity<HistoryLog>();
            historyLogConfiguration.HasKey(x => x.Id);
            historyLogConfiguration.Property(x => x.EntityId).IsRequired();
            historyLogConfiguration.Property(x => x.EntityType).IsRequired();
        }
    }
}
