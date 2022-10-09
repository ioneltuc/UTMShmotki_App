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
    public class GetAllProductsQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepo;

        public GetAllProductsQueryTests()
        {
            _mockRepo = MockRepositories.GetMockProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAll_Returns_ListOfProductType()
        {
            //Arange
            var handler = new GetAllProductsQueryHandler(_mockRepo.Object, _mapper);

            //Act
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            //Assert
            Assert.IsType<List<ProductListDto>>(result);
        }

        [Fact]
        public async Task GetAll_ReturnsExactCount_OfProductList()
        {
            //Arange
            var handler = new GetAllProductsQueryHandler(_mockRepo.Object, _mapper);

            //Act
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            //Assert
            Assert.Equal(2, result.Count());
        }
    }
}