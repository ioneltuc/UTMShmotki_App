using AutoMapper;
using MediatR;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Domain;

namespace UTMShmotki.Application.App.Products.Queries
{
    public class GetProductsPaginatedQuery : IRequest<IEnumerable<ProductPaginatedDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; } 
        public string SortType { get; set; } 
    }

    public class GetProductsPaginatedQueryHandler : IRequestHandler<GetProductsPaginatedQuery, IEnumerable<ProductPaginatedDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsPaginatedQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductPaginatedDto>> Handle(GetProductsPaginatedQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetPaginatedAsync(query.PageNumber, query.PageSize, query.SearchString, query.SortType);
            var porductsPaginatedDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductPaginatedDto>>(products);

            return porductsPaginatedDto;
        }
    }
}