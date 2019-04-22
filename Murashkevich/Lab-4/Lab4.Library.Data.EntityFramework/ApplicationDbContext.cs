using System.Data.Entity;
using Lab4.Library.Data.Contracts.Entities;

namespace Lab4.Library.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ConnectionLibrary") { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();
            bookConfiguration.Property(x => x.Description).IsRequired();
            bookConfiguration.Property(x => x.CreatedBy).IsOptional();
            bookConfiguration.Property(x => x.Create).IsOptional();
        }
    }
}
