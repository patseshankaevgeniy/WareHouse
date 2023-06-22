using AutoMapper;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Products.Models;

public class ProductAutoMapper : Profile
{
    public ProductAutoMapper()
    {
        CreateMap<Product, ProductModel>().ReverseMap();
    }
}
