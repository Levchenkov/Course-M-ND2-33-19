namespace Lab3.DAL.EntityFrame
{
    using System;
    using System.Data.Entity;
    using Lab3.DAL.Contracts.Entities;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using Newtonsoft.Json;
    using System.Data.Entity.ModelConfiguration;

    public class BookContext : DbContext
    {
        
        public BookContext()
            : base("name = BookContext")
        {
        }
                
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }

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

            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Genre).WithMany(x => x.Books);
            HasMany(x => x.Languages).WithMany(x => x.Books);
            HasRequired(x => x.Delivery).WithMany(x => x.Books);
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

    
