using AutoMapper;
using WareHouse.Application.Products.Models;

namespace WareHouse.Api.Dtos.AutoMappers;

public class ProductDtoAutoMapper : Profile
{
    public ProductDtoAutoMapper()
    {
        CreateMap<ProductModel, ProductDto>().ReverseMap();
        CreateMap<ProductPatchModel, ProductPatchDto>().ReverseMap();
    }
}
