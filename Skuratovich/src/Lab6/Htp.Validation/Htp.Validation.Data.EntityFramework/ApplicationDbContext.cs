using System.IO;
using Htp.Validation.Data.Contracts.Entities;
using Htp.Validation.Data.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Htp.Validation.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        // cd Projects/Course-M-ND2-33-19/Skuratovich/src/Lab6/Htp.Validation/Htp.Validation.Data.EntityFramework/
        //
        // dotnet ef migrations add InitialCreate
        //
        // dotnet ef database update

        public virtual DbSet<Payment> Payments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string wanted_path = Path.GetDirectoryName(Directory.GetCurrentDirectory());

        //    optionsBuilder.UseSqlite($"Filename={wanted_path}/app.db");

        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
        }

    }
}
