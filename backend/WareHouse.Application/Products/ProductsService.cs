using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Products.Models;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Products;

public class ProductsService : IProductsService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDto> _validator;

    public ProductsService(
        IGenericRepository<Product> productRepository,
        IMapper mapper,
        IValidator<ProductDto> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(_mapper.Map<ProductDto>).ToList();
    }

    public async Task<ProductDto> GetAsync(int id)
    {
        if (id <= 0)
        {

        }

        var product = await _productRepository.FirstAsync(x => x.Id == id);

        if (product == null)
        {
            return null;
        }

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(ProductDto productDto)
    {
        var result = _validator.Validate(productDto);
        if (!result.IsValid)
        {

        }

        var product = new Product
        {
            Name = productDto.Name,
            DepartmentId = productDto.DepartmentId,
        };

        product = await _productRepository.CreateAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {

        }

        var product = await _productRepository.GetAsync(id);

        if (product == null)
        {

        }

        await _productRepository.DeleteAsync(product);
    }
}
