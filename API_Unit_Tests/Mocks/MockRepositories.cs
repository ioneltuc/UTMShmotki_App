using Moq;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace API_Unit_Tests.Mocks
{
    public static class MockRepositories
    {
        public static Mock<IProductRepository> GetMockProductRepository()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Description = "White",
                    Price = 15
                },
                new Product()
                {
                    Id = 2,
                    Name = "Jeans",
                    Description = "Black",
                    Price = 30
                },
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(x => x.GetAllAsync<Product>()).ReturnsAsync(products);
            mockRepo.Setup(x => x.GetByIdAsync<Product>(2)).ReturnsAsync(products[1]);
            mockRepo.Setup(x => x.AddEntityAsync<Product>(It.IsAny<Product>()));

            return mockRepo;
        }
    }
}