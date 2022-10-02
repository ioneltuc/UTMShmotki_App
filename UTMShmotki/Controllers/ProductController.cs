using Microsoft.AspNetCore.Mvc;
using UTMShmotki.Application.Interfaces;
using UTMShmotki.Domain;

namespace UTMShmotki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            var products = _service.GetAllProducts();

            return products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            var product = _service.GetProductById(id);

            return product;
        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            _service.AddProduct(product);
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody]Product product)
        {
            _service.UpdateProductById(id, product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _service.DeleteProductById(id);
        }
    }
}
