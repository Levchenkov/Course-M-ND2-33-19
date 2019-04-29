using System.Collections.Generic;
using Http.BooksLibrary.Data.Contracts.Entities;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;

namespace Http.BooksLibrary.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Http.BooksLibrary.Data.EntityFramework.ApplicationDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDbContext' 
        // connection string in the application configuration file.

        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=Http.BooksLibrary;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var bookConfiguration = modelBuilder.Entity<Book>();
            bookConfiguration.Ignore(x => x.LongVersion);
            bookConfiguration.HasKey(x => x.Id);
            bookConfiguration.Property(x => x.Title).IsRequired();

        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public override int SaveChanges()
        {
            var listOfChanges = new List<HistoryLog>();

            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);


            foreach (var entry in entries)
            {
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                if (entityType == typeof(Book))
                {
                    var postId = ((Book)entry.Entity).Id;
                    var originalEntity = Set(entityType).AsNoTracking().Cast<Book>().First(x => x.Id == postId);

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
}
