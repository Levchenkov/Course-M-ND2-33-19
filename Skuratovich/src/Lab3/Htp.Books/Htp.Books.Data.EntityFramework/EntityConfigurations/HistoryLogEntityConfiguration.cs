using Htp.Books.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Books.Data.EntityFramework.EntityConfigurations
{
    public class HistoryLogEntityConfiguration : IEntityTypeConfiguration<HistoryLog>
    {
        public void Configure(EntityTypeBuilder<HistoryLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.EntityType).IsRequired();
        }
    }
}
