using System.Data.Entity.ModelConfiguration;
using Lab.Library.Data.Contracts.Entities;

namespace Lab.Library.Data.EntityFramework.EntitiesConfiguration
{
    public class BookTypeConfiguration : EntityTypeConfiguration<Book>
    {
        public BookTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired();
            Property(x => x.Description).IsRequired();
            Property(x => x.Author).IsRequired();
            Property(x => x.Created).IsRequired();
            HasRequired(x => x.Genre).WithMany(x => x.Books);
            Property(x => x.IsPaper).IsRequired();
            HasMany(x => x.Languages).WithMany(x => x.Books);
            Property(x => x.DeliveryRequired).IsRequired();
        }
    }
}
