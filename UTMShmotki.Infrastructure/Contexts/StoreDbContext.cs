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

        private const string connectionString = "Data Source=IONELTUC;Initial Catalog=UTMShmotki;" +
             "Integrated Security=True;Connect Timeout=30;" +
             "Encrypt=False;TrustServerCertificate=False;" +
             "ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
        }
    }
}