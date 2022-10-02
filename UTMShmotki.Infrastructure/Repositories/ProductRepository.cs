using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        public override void UpdateById<T>(int id, T newEntity)
        {
            var product = _storeDbContext.Set<Product>().Find(id);

            if (product == null)
            {
                throw new ValidationException($"Object of type {typeof(Product)} with id {id} not found");
            }
           
            product.Name = "Jeans";
            product.Description = "Blue";
            product.Price = 20;

            _storeDbContext.SaveChanges();
        }
    }
}