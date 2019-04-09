using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Htp.BooksAPI.Data.Contracts.Entities;
using Htp.BooksAPI.Data.EntityFramework.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Htp.BooksAPI.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        // cd Projects/Course-M-ND2-33-19/Skuratovich/src/Lab4/Htp.BooksAPI/Htp.Books.Data.EntityFramework/
        //
        // dotnet ef migrations add InitialCreate
        //
        // dotnet ef database update

        //public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string wanted_path = Path.GetDirectoryName(Directory.GetCurrentDirectory());

            optionsBuilder.UseSqlite($"Filename={wanted_path}/app.db");

            //    //optionsBuilder.UseSqlServer(
            //    //@"Server = localhost, 1433; Database = BookCatalogAPI;"
            //    //+ "User = SA; Password = $zDkJDCmx8CNcJh");

            //optionsBuilder.UseSqlite("Data Source=app.db");

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserEntityConfiguration());
            builder.ApplyConfiguration(new BookEntityConfiguration());
        }

        public override int SaveChanges()
        {
            //this.ChangeTracker.DetectChanges();

            //var addedBooks = this.ChangeTracker.Entries<Book>()
            //            .Where(t => t.State == EntityState.Added)
            //            .Select(t => t.Entity)
            //            .ToList();

            //addedBooks.ForEach(e =>
            //{
            //    e.Created = DateTime.UtcNow;
            //});

            //var modifiedBooks = this.ChangeTracker.Entries<Book>()
            //            .Where(t => t.State == EntityState.Modified)
            //            .Select(t => t.Entity)
            //            .ToList();

            //modifiedBooks.ForEach(e =>
            //{
            //    e.Updated = DateTime.UtcNow;
            //});

            PopulateDate();

            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            PopulateDate();
            return await base.SaveChangesAsync();
        }

        private void PopulateDate()
        {
            this.ChangeTracker.DetectChanges();

            var addedBooks = this.ChangeTracker.Entries<Book>()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToList();

            addedBooks.ForEach(e =>
            {
                e.Created = DateTime.UtcNow;
            });

            var modifiedBooks = this.ChangeTracker.Entries<Book>()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToList();

            modifiedBooks.ForEach(e =>
            {
                e.Updated = DateTime.UtcNow;
            });
        }
    }
}
