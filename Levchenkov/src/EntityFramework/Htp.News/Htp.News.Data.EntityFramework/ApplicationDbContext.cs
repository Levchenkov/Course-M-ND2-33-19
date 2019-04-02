using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Htp.News.Data.Contracts.Entities;
using Newtonsoft.Json;

namespace Htp.News.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        //static ApplicationDbContext()
        //{
        //    var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        //    if (type == null)
        //        throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        //}

        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=Htp.News;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostTypeConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            
            modelBuilder.ComplexType<Address>();

                //addressConfiguration.Property(x => x.City).HasColumnName(nameof(Address.City));
                //addressConfiguration.Property(x => x.Country).HasColumnName(nameof(Address.Country));
                //addressConfiguration.Property(x => x.Street).HasColumnName(nameof(Address.Street));
        }

        public override int SaveChanges()
        {
            var listOfChanges = new List<HistoryLog>();

            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            
            foreach (var entry in entries)
            {
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                if (entityType == typeof(Post))
                {
                    var postId = ((Post) entry.Entity).Id;
                    var originalEntity = Set(entityType).AsNoTracking().Cast<Post>().First(x => x.Id == postId);

                    var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var log = new HistoryLog
                    {
                        EntityId = postId,
                        EntityType = entityType.Name,
                        OriginalValue = JsonConvert.SerializeObject(originalEntity, settings),
                        ActualValue = JsonConvert.SerializeObject(entry.Entity, settings)
                    };
                    listOfChanges.Add(log);
                }
            }

            return base.SaveChanges();
        }
    }

    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {
            HasRequired(x => x.Profile);
        }
    }

    public class PostTypeConfiguration : EntityTypeConfiguration<Post>
    {
        public PostTypeConfiguration()
        {

            Ignore(x => x.LongVersion);
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Author).WithMany(x => x.Posts);
            HasMany(x => x.Tags).WithMany(x => x.Posts);
        }
    }

    public class HistoryLog
    {
        public int Id { get; set; }

        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValue { get; set; }
        public string ActualValue { get; set; }
    }
}
