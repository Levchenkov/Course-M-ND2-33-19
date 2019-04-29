using Course.RESTapi.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.RESTapi.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=Course.RESTapi;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();
            bookConfiguration.Property(x => x.Created).IsRequired();
            bookConfiguration.Property(x => x.CreatedBy).IsRequired();
            bookConfiguration.Property(x => x.Description).IsRequired();
        }
    }
}
