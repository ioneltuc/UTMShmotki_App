using MediatR;
using Microsoft.AspNetCore.Mvc;
using UTMShmotki.Application.App.Products;
using UTMShmotki.Application.App.Products.Commands;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.App.Products.Queries;

namespace UTMShmotki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery() { ProductId = id });   

            return productDto;
        }

        [HttpGet]
        public async Task<List<ProductPaginatedDto>> GetPaginatedProducts([FromQuery] PaginationQuery query)
        {
            var productPaginatedDto = await _mediator.Send(new GetProductsPaginatedQuery()
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                SearchString = query.Search,
                SortType = query.Sort
            });

            return productPaginatedDto.ToList();
        }

        [HttpPost]
        public async Task<ProductDto> CreateProduct(CreateProductCommand product)
        {
            var productDto = await _mediator.Send(product);
            return productDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(int id, UpdateProductCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand() { Id = id });
        }
    }
}