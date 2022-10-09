using AutoMapper;
using MediatR;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById<Product>(query.ProductId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}