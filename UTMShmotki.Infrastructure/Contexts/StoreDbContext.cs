using Microsoft.EntityFrameworkCore;
using UTMShmotki.Domain;
using UTMShmotki.Infrastructure.Configurations;

namespace UTMShmotki.Infrastructure.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
        }
    }
}