using Htp.Library.Data.Contracts.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace Htp.Library.Data.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(
            "Server=(localdb)\\mssqllocaldb;Database=Htp.Library;Trusted_Connection=True;MultipleActiveResultSets=true")
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookTypeConfiguration());
        }

        public override int SaveChanges()
        {
            var listOfChanges = new List<HistoryLog>();

            var entries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                if (entityType == typeof(Book))
                {
                    var bookId = ((Book)entry.Entity).Id;
                    var originalEntity = Set(entityType).AsNoTracking().Cast<Book>().First(x => x.Id == bookId);

                    var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var log = new HistoryLog
                    {
                        EntityId = bookId,
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
    public class BookTypeConfiguration : EntityTypeConfiguration<Book>
    {
        public BookTypeConfiguration()
        {
            Ignore(x => x.LongVersion);
            HasKey(x => x.Id);
            Property(x => x.Author).IsRequired();
            Property(x => x.Title).IsRequired();
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