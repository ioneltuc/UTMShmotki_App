using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTMShmotki.Domain;

namespace UTMShmotki.Infrastructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(64);
        }
    }
}