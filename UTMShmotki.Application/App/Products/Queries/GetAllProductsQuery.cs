using AutoMapper;
using MediatR;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductListDto>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductListDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductListDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync<Product>();
            var porductsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductListDto>>(products);
            return porductsDto;
        }
    }
}