using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateProductCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);
            await _repository.AddEntityAsync(product);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
    }
}