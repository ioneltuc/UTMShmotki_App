using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMShmotki.Domain;

namespace UTMShmotki.Infrastructure.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ApartmentNumber).IsRequired(false);
            builder.Property(x => x.PostalCode).IsRequired(false);

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Customer).WithOne(x => x.Address).HasForeignKey<Address>(y => y.CustomerId);
        }
    }
}