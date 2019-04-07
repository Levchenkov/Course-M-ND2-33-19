using BookEditing.DAL.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;

namespace BookEditing.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BookContext() : base("BookContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookTypeConfiguration());

            modelBuilder.Entity<Book>()
           .HasMany(p => p.Languages)
           .WithMany(c => c.Books);
        }
        public override int SaveChanges()
        {
            var listOfChanges = new List<СhangeHistory>();
            var entitiesModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entity in entitiesModified)
            {
                var entityType = ObjectContext.GetObjectType(entity.Entity.GetType());
                if (entityType==typeof(Book))
                {
                    var bookId = ((Book)entity.Entity).Id;
                    var original= Set(entityType).AsNoTracking().Cast<Book>().First(x => x.Id == bookId);
                    var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

                    var log = new СhangeHistory
                    {
                        EntityId = bookId,
                        EntityType = entityType.Name,
                        OriginalValue = JsonConvert.SerializeObject(original, settings),
                        ActualValue = JsonConvert.SerializeObject(entity.Entity, settings)
                    };
                    listOfChanges.Add(log);                  
                }
                File.WriteAllText(@"d:\file.json", JsonConvert.SerializeObject(listOfChanges));
            }           
            var result = base.SaveChanges();
            return result;
        }
    }

    public class BookTypeConfiguration: EntityTypeConfiguration<Book>
    {
        public BookTypeConfiguration()
        {
            Property(x => x.Author).IsRequired();
            Property(x => x.Title).IsRequired();
            HasMany(p => p.Languages).WithMany(c => c.Books);
        }
    }
    public class СhangeHistory
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string OriginalValue { get; set; }
        public string ActualValue { get; set; }
    }
}