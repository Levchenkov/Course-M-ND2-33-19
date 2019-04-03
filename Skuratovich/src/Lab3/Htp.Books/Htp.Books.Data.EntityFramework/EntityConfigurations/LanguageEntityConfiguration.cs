using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Books.Data.EntityFramework.EntityConfigurations
{
    public class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.HasData(new Genre { Id = 1, Title = "English" },
                  new Genre { Id = 2, Title = "German" },
                  new Genre { Id = 3, Title = "Russian" });
        }
    }
}
