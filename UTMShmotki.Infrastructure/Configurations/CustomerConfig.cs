using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMShmotki.Domain;

namespace UTMShmotki.Infrastructure.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Age).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}