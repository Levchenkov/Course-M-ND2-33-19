using Htp.BooksAPI.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.BooksAPI.Data.EntityFramework.EntityConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Updated).IsRequired();

            //builder.Property(x => x.RowVersion).IsRowVersion().IsRequired();
            //builder.Ignore(x => x.LongRowVersion);
        }
    }
}
