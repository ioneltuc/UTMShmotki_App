using AutoMapper;
using MediatR;
using UTMShmotki.Application.App.Products.Dto;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
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
            var product = _repository.GetById<Product>(query.Id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}