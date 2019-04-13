using Htp.BooksAPI.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.BooksAPI.Data.EntityFramework.EntityConfigurations
{
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.HasMany(x => x.CreatedBooks).WithOne(x => x.CreatedBy);
            builder.HasMany(x => x.UpdatedBooks).WithOne(x => x.UpdatedBy);
            builder.HasMany(x => x.Claims).WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
        }
    }
}
