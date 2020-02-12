using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Http.News.Data.Contracts.Entities;
using Http.News.Data.EntityFramework.Migrations;
using Newtonsoft.Json;

namespace Http.News.Data.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public class NewsDbContext : DbContext
    {
        // Your context has been configured to use a 'NewsDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Http.News.Data.EntityFramework.NewsDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewsDbContext' 
        // connection string in the application configuration file.
        public NewsDbContext()
            : base("Server=(localdb)\\mssqllocaldb;Database=Http.ITNews;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<NewsDbContext, NewsDbMigrationsConfiguration>()
            );
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var bookConfiguration = modelBuilder.Entity<Item>();
        //    bookConfiguration.Ignore(x => x.LongVersion);
        //    bookConfiguration.HasKey(x => x.Id);
        //    bookConfiguration.Property(x => x.Title).IsRequired();
        //}

        //public override int SaveChanges()
        //{
        //    var listOfChanges = new List<HistoryLog>();

        //    var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);


        //    foreach (var entry in entries)
        //    {
        //        var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
        //        if (entityType == typeof(Item))
        //        {
        //            var postId = ((Item)entry.Entity).Id;
        //            var originalEntity = Set(entityType).AsNoTracking().Cast<Item>().First(x => x.Id == postId);

        //            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        //            var log = new HistoryLog
        //            {
        //                EntityId = postId,
        //                EntityType = entityType.Name,
        //                OriginalValue = JsonConvert.SerializeObject(originalEntity, settings),
        //                ActualValue = JsonConvert.SerializeObject(entry.Entity, settings)
        //            };
        //            listOfChanges.Add(log);
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}