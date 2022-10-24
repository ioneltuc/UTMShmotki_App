using AutoMapper;
using UTMShmotki.Application.App.Products.Commands;
using UTMShmotki.Application.App.Products.Dtos;
using UTMShmotki.Application.App.Products.Queries;
using UTMShmotki.Domain;

namespace UTMShmotki.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductPaginatedDto>().ReverseMap();
        }
    }
}