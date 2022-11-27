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

        public async Task<List<Product>> GetPaginatedAsync(int pageNumber, int pageSize, string searchString, string sortType)
        {
            var result = _storeDbContext.Products.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));

            switch(sortType)
            {
                case "name":
                    result = result.OrderBy(p => p.Name);
                    break;
                case "namedesc":
                    result = result.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    result = result.OrderBy(p => p.Price);
                    break;
                case "pricedesc":
                    result = result.OrderByDescending(p => p.Price);
                    break;
                case "lastadded":
                    result = result.OrderByDescending(p => p.Id);
                    break;
            }

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await result.ToListAsync();
        }
    }
}