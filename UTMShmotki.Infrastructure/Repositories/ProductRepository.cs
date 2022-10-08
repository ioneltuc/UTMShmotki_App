using UTMShmotki.Application.Interfaces.Repositories;
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
    }
}