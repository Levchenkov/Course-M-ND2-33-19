using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Prikhodko.BookCatalogue.Data.Contracts.Models;

namespace Prikhodko.BookCatalogue.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var booksConfiguration = modelBuilder.Entity<Book>();
            booksConfiguration.HasKey(x => x.Id);
            booksConfiguration.Property(x => x.Title).IsRequired();
            booksConfiguration.Property(x => x.Description).IsOptional();
            booksConfiguration.HasRequired(x => x.Author).WithMany(x => x.Books);
            booksConfiguration.Property(x => x.DateOfIssue).IsRequired();
            booksConfiguration.Property(x => x.Genre).IsRequired();
            booksConfiguration.Property(x => x.IsPaper).IsRequired();
            booksConfiguration.Property(x => x.DeliveryOption).IsRequired();
            booksConfiguration.HasMany(x => x.AvailableLanguages).WithMany(x => x.Books);

            var authorConfiguration = modelBuilder.Entity<Author>();
            authorConfiguration.HasKey(x => x.Id);
            authorConfiguration.Property(x => x.FirstName).IsRequired();
            authorConfiguration.Property(x => x.LastName).IsOptional();
            authorConfiguration.HasMany(x => x.Books).WithRequired(x => x.Author);

            var languageConfiguration = modelBuilder.Entity<Language>();
            languageConfiguration.HasKey(x => x.Id);
            languageConfiguration.Property(x => x.Name).IsRequired();
            languageConfiguration.Property(x => x.Code).IsRequired();
            languageConfiguration.HasMany(x => x.Books).WithMany(x => x.AvailableLanguages);
        }

    }
}
