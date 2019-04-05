using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts.Entities;


namespace Course.Library.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=Course.Library;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();
            bookConfiguration.HasRequired(x => x.Author).WithMany(x => x.Books);
            bookConfiguration.HasMany(x => x.Languages).WithMany(x => x.Books);
            bookConfiguration.HasOptional(x => x.Genre).WithMany(x => x.Books);
            var authorConfiguration = modelBuilder.Entity<Author>();
            authorConfiguration.HasRequired(x => x.Profile);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}