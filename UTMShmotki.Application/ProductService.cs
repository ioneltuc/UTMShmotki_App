using UTMShmotki.Application.Interfaces;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddEntity<Product>(product);
        }

        public void DeleteProductById(int id)
        {
            _productRepository.DeleteById<Product>(id);
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll<Product>();

            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetById<Product>(id);

            return product;
        }

        public void UpdateProductById()
        {
            _productRepository.UpdateById<Product>();
        }
    }
}