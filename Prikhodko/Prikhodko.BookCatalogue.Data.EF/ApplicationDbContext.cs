using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Prikhodko.BookCatalogue.Data.Contracts.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DbSet<BookChange> BookChanges { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        internal Dictionary<string, object> GetChangedValues(System.Data.Entity.Infrastructure.DbEntityEntry entry)
        {
            var currentValues = entry.CurrentValues;
            var originalValues = entry.OriginalValues;
            var changedValues = new Dictionary<string, object>();
            var propertyNames = currentValues.PropertyNames;
            foreach(var propertyName in propertyNames)
            {
                var currentValue = currentValues.GetValue<object>(propertyName);
                if (currentValue.ToString() != originalValues.GetValue<object>(propertyName).ToString())
                {
                    changedValues[propertyName] = currentValue;
                }
            }
            return changedValues;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var booksConfiguration = modelBuilder.Entity<Book>();
            booksConfiguration.HasKey(x => x.BookId);
            booksConfiguration.Property(x => x.Title).IsRequired();
            booksConfiguration.Property(x => x.Description).IsOptional();
            booksConfiguration.HasRequired(x => x.Author).WithMany(x => x.Books);
            booksConfiguration.Property(x => x.DateOfIssue).IsRequired();
            booksConfiguration.Property(x => x.Genre).IsRequired();
            booksConfiguration.Property(x => x.IsPaper).IsRequired();
            booksConfiguration.Property(x => x.DeliveryOption).IsRequired();
            booksConfiguration.HasMany(x => x.AvailableLanguages).WithMany(x => x.Books);
            booksConfiguration.HasMany(x => x.BookChanges).WithRequired(x => x.Book);
            
            var authorConfiguration = modelBuilder.Entity<Author>();
            authorConfiguration.HasKey(x => x.AuthorId);
            authorConfiguration.Property(x => x.FirstName).IsRequired();
            authorConfiguration.Property(x => x.LastName).IsOptional();
            authorConfiguration.HasMany(x => x.Books).WithRequired(x => x.Author);

            var languageConfiguration = modelBuilder.Entity<Language>();
            languageConfiguration.Property(x => x.Name).IsRequired();
            languageConfiguration.Property(x => x.Code).IsRequired();
            languageConfiguration.HasMany(x => x.Books).WithMany(x => x.AvailableLanguages);

            var bookChangeConfiguration = modelBuilder.Entity<BookChange>();
            bookChangeConfiguration.HasKey(x => x.BookChangeId);
            bookChangeConfiguration.Property(x => x.ChangedProperty).IsRequired();
            bookChangeConfiguration.Property(x => x.NewValue).IsRequired();
            bookChangeConfiguration.Property(x => x.TimeOfChange).IsRequired();
            bookChangeConfiguration.HasRequired(x => x.Book).WithMany(x => x.BookChanges);
        }

    }
}
