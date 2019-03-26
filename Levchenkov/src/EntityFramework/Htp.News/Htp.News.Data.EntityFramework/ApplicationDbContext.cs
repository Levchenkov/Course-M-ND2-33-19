using System.Data.Entity;
using Htp.News.Data.Contracts.Entities;

namespace Htp.News.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=Htp.News;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var postConfiguration = modelBuilder.Entity<Post>();

            postConfiguration.HasKey(x => x.Id);
            postConfiguration.Property(x => x.Title).IsRequired();

            postConfiguration.HasRequired(x => x.Author).WithMany(x => x.Posts);
            postConfiguration.HasMany(x => x.Tags).WithMany(x => x.Posts);

            var userConfiguration = modelBuilder.Entity<User>();
            userConfiguration.HasRequired(x => x.Profile);
            
                var addressConfiguration = modelBuilder.ComplexType<Address>();

                addressConfiguration.Property(x => x.City).HasColumnName(nameof(Address.City));
                addressConfiguration.Property(x => x.Country).HasColumnName(nameof(Address.Country));
                addressConfiguration.Property(x => x.Street).HasColumnName(nameof(Address.Street));
        }
    }
}
