using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMShmotki.Domain;

namespace UTMShmotki.Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Price).HasDefaultValue(0).IsRequired();
        }
    }
}