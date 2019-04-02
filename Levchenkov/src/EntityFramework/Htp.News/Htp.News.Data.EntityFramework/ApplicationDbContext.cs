using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            var postConfiguration = modelBuilder.Entity<Post>();

            postConfiguration.Ignore(x => x.LongVersion);
            //postConfiguration.Property(x => x.Version).IsRowVersion();
            postConfiguration.HasKey(x => x.Id);
            postConfiguration.Property(x => x.Title).IsRequired();

            postConfiguration.HasRequired(x => x.Author).WithMany(x => x.Posts);
            postConfiguration.HasMany(x => x.Tags).WithMany(x => x.Posts);

            var userConfiguration = modelBuilder.Entity<User>();
            userConfiguration.HasRequired(x => x.Profile);
            
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

    public class HistoryLog
    {
        public int Id { get; set; }

        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValue { get; set; }
        public string ActualValue { get; set; }
    }
}
