﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTMShmotki.Application.App.Products;
using UTMShmotki.Application.App.Products.Commands;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.App.Products.Queries;
using UTMShmotki.Domain;

namespace UTMShmotki.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery() { ProductId = id });

            return productDto;
        }

        [HttpGet]
        [AllowAnonymous]
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

        [HttpPost("UploadImage")]
        public async Task<string> UploadImage([FromForm] FileUpload fileUpload, string productId)
        {
            try
            {
                if(fileUpload.formFile.Length > 0)
                {
                    var path = _webHostEnvironment.WebRootPath + "\\Uploads\\Products\\";
                    var imagePath = path + fileUpload.formFile.FileName;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var newImagePath = imagePath.Replace(Path.GetFileName(imagePath), productId + ".png");
                    using (FileStream fileStream = System.IO.File.Create(newImagePath))
                    {
                        await fileUpload.formFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return "Upload Done";
                    }
                }
                else
                {
                    return "Upload Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("image/{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImage([FromRoute] string productId)
        {
            var path = _webHostEnvironment.WebRootPath + "\\Uploads\\Products\\";
            var filePath = path + productId + ".png";
            if(System.IO.File.Exists(filePath))
            {
                byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(imageBytes, "image/png");
            }

            return null;
        }
    }
}