using Htp.Validation.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Htp.Validation.Data.EntityFramework.EntityConfigurations
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.MiddleName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.PostCode).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.CreditCardNumber).IsRequired().HasMaxLength(16);
            builder.Property(x => x.ExpirationMonth).IsRequired().HasMaxLength(2);
            builder.Property(x => x.ExpirationYear).IsRequired().HasMaxLength(2);
            builder.Property(x => x.SecurityCode).IsRequired().HasMaxLength(3);
        }
    }
}
