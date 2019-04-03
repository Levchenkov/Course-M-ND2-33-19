using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Books.Data.EntityFramework.EntityConfigurations
{
    public class BookLanguageEntityConfiguration : IEntityTypeConfiguration<BookLanguage>
    {
        public void Configure(EntityTypeBuilder<BookLanguage> builder)
        {
            builder.HasKey(x => new { x.BookId, x.LanguageId });
            builder.HasOne(x => x.Book).WithMany(x => x.BookLanguages).HasForeignKey(x => x.BookId);
            builder.HasOne(x => x.Language).WithMany(x => x.BookLanguages).HasForeignKey(x => x.LanguageId);
            builder.Ignore(x => x.Id);
        }
    }
}
