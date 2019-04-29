using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Library.Data.Contracts.Entities;
using Newtonsoft.Json;


namespace Course.Library.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(
            "Server=(localdb)\\mssqllocaldb;Database=Course.Library;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Log> Logs { get; set; }

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
            var logConfiguration = modelBuilder.Entity<Log>();
            logConfiguration.HasKey(x => x.Id);

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                if (entityType == typeof(Book))
                {
                    var bookId = ((Book)entry.Entity).Id;
                    var originalEntity = Set(entityType).AsNoTracking().Cast<Book>().First(x => x.Id == bookId);

                    var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var log = new Log
                    {
                        EntityId = bookId,
                        EntityType = entityType.Name.ToString(),
                        OriginalValue = JsonConvert.SerializeObject(originalEntity, settings),
                        ActualValue = JsonConvert.SerializeObject(entry.Entity, settings)
                    };
                    Set<Log>().Add(log);
                }
            }
            return base.SaveChanges();
        }
    }
}