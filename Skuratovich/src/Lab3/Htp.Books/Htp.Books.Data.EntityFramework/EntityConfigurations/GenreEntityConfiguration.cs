using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Books.Data.EntityFramework.EntityConfigurations
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.HasData(new Genre { Id = 1, Title = "Anthology" },
                            new Genre { Id = 2, Title = "Crime" },
                            new Genre { Id = 3, Title = "Fantasy" },
                            new Genre { Id = 4, Title = "Drama" },
                            new Genre { Id = 5, Title = "Horror" });
            //modelBuilder.Entity<Blog>().HasData(new Blog { BlogId = 1, Url = "http://sample.com" });
        }
    }
}
