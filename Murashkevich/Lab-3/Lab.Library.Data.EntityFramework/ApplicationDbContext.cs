using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;
using Lab.Library.Data.Contracts.Entities;
using Lab.Library.Data.EntityFramework.EntitiesConfiguration;
using Newtonsoft.Json;

namespace Lab.Library.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Library") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HistoryLog> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookTypeConfiguration());
            modelBuilder.Configurations.Add(new GenreTypeConfiguration());
            modelBuilder.Configurations.Add(new LanguageTypeConfiguration());
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

                    var setting = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

                    var log = new HistoryLog
                    {
                        EntityId = bookId,
                        EntityType = entityType.Name,
                        OriginalValues = JsonConvert.SerializeObject(originalEntity, setting),
                        ActualValues = JsonConvert.SerializeObject(entry.Entity, setting)
                    };
                    Set<HistoryLog>().Add(log);
                }
            }
            return base.SaveChanges();
        }
    }
}
