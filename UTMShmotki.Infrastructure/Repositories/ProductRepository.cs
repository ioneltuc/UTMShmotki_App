using Microsoft.EntityFrameworkCore;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;
using UTMShmotki.Infrastructure.Contexts;

namespace UTMShmotki.Infrastructure.Repositories
{
    public class ProductRepository : EFCoreRepository, IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<List<Product>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _storeDbContext.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}