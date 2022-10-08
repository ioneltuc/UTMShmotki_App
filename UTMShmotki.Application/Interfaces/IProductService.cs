using UTMShmotki.Domain;

namespace UTMShmotki.Application.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProductById();
        void DeleteProductById(int id);
    }
}