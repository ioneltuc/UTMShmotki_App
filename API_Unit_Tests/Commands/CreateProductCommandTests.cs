using API_Unit_Tests.Mocks;
using AutoMapper;
using Moq;
using UTMShmotki.Application;
using UTMShmotki.Application.App.Products.Commands;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using Xunit;

namespace API_Unit_Tests.Commands
{
    public class CreateProductCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepo;

        public CreateProductCommandTests()
        {
            _mockRepo = MockRepositories.GetMockProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateProduct_Returns_CorectProductType()
        {
            //Arange
            var handler = new CreateProductCommandHandler(_mapper, _mockRepo.Object);

            //Act
            var result = await handler.Handle(new CreateProductCommand()
            {
                Name = "Shoes",
                Description = "For running",
                Price = 70
            }, CancellationToken.None);

            //Assert
            Assert.IsType<ProductDto>(result);
        }

        [Fact]
        public async Task CreateProduct_Returns_CorectProduct()
        {
            //Arange
            var handler = new CreateProductCommandHandler(_mapper, _mockRepo.Object);
            var product = new ProductDto()
            {
                Name = "Shoes",
                Description = "For running",
                Price = 70
            };

            //Act
            var result = await handler.Handle(new CreateProductCommand()
            {
                Name = "Shoes",
                Description = "For running",
                Price = 70
            }, CancellationToken.None);

            //Assert
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Price, result.Price);
        }
    }
}