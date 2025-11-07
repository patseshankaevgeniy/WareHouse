using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Exceptions;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Products.Models;
using WareHouse.Domain.Entities;
using ValidationException = WareHouse.Application.Common.Exceptions.ValidationException;

namespace WareHouse.Application.Products;

public class ProductsService : IProductsService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductModel> _validator;

    public ProductsService(
        IGenericRepository<Product> productRepository,
        IMapper mapper,
        IValidator<ProductModel> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<List<ProductModel>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(_mapper.Map<ProductModel>).ToList();
    }

    public async Task<List<ProductModel>> GetByDepartmentIdAsync(int departmentId)
    {
        if (departmentId <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var products = await _productRepository.FindAsync(x => x.DepartmentId == departmentId);
            

        if (products == null)
        {
            throw new NotFoundException($"Can't find products with departmentId: {departmentId}");
        }


        return  products.Select(_mapper.Map<ProductModel>).ToList();
    }

    public async Task<ProductModel> CreateAsync(ProductModel productDto)
    {
        var result = _validator.Validate(productDto);
        if (!result.IsValid)
        {
            throw new ValidationException(result.ToString());
        }

        var product = new Product
        {
            Name = productDto.Name,
            DepartmentId = productDto.DepartmentId,
        };

        product = await _productRepository.CreateAsync(product);
        return _mapper.Map<ProductModel>(product);
    }

    public async Task<ProductModel> UpdateAsync(int id, ProductPatchModel productPatchDto)
    {
        var product = await _productRepository.FirstAsync(x => x.Id == id);
        if (product == null)
        {
            throw new NotFoundException($"Can't find products with id: {id}");
        }

        if (productPatchDto.Name != null && productPatchDto.DepartmentId > 0)
        {
            if (product.DepartmentId != productPatchDto.DepartmentId || product.Name != productPatchDto.Name)
            {
                product.DepartmentId = productPatchDto.DepartmentId;
                product.Name = productPatchDto.Name;
                await _productRepository.UpdateAsync(product);
            }
        }

        return _mapper.Map<ProductModel>(product);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var product = await _productRepository.GetAsync(id);

        if (product == null)
        {
            throw new NotFoundException($"Can't find product with id: {id}");
        }

        await _productRepository.DeleteAsync(product);
    }
}
