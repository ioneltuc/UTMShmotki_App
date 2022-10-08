﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UTMShmotki.Application.App.Products.Commands;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.App.Products.Queries;
using UTMShmotki.Application.Interfaces;
using UTMShmotki.Domain;

namespace UTMShmotki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMediator _mediator;

        public ProductController(IProductService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductListDto>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return products.ToList();
        }

        [HttpGet("{id}")]
        public Task<ProductDto> GetProduct(int id)
        {
            var productDto = _mediator.Send(new GetProductByIdQuery() { ProductId = id });

            return productDto;
        }

        [HttpPost]
        public Task<ProductDto> CreateProduct(CreateProductCommand product)
        {
            var productDto = _mediator.Send(product);

            return productDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(int id, UpdateProductCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _service.DeleteProductById(id);
        }
    }
}