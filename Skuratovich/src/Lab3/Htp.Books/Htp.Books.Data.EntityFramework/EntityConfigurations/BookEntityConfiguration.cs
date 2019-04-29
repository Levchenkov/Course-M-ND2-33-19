using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Books.Data.EntityFramework.EntityConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsPaper).IsRequired();
            builder.Property(x => x.DeliveryRequired).IsRequired();
            builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
            builder.Ignore(x => x.LongRowVersion);
            builder.HasOne(x => x.Genre).WithMany(x => x.Books);
            builder.HasOne(x => x.Genre).WithMany(x => x.Books).HasForeignKey(x => x.GenreId);
        }
    }
}
