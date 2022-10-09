using API_Unit_Tests.Mocks;
using AutoMapper;
using Moq;
using UTMShmotki.Application;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.App.Products.Queries;
using UTMShmotki.Application.Interfaces.Repositories;
using Xunit;

namespace API_Unit_Tests.Queries
{
    public class GetProductByIdQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepo;

        public GetProductByIdQueryTests()
        {
            _mockRepo = MockRepositories.GetMockProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetById_Returns_CorectProductId()
        {
            //Arange
            var handler = new GetProductByIdQueryHandler(_mockRepo.Object, _mapper);

            //Act
            var result = await handler.Handle(new GetProductByIdQuery() { ProductId = 2}, CancellationToken.None);

            //Assert
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task GetById_Returns_CorectProductType()
        {
            //Arange
            var handler = new GetProductByIdQueryHandler(_mockRepo.Object, _mapper);

            //Act
            var result = await handler.Handle(new GetProductByIdQuery() { ProductId = 2 }, CancellationToken.None);

            //Assert
            Assert.IsType<ProductDto>(result);
        }
    }
}