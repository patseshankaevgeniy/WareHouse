using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Api.Dtos;
using WareHouse.Application.Common.Models;
using WareHouse.Application.Products;
using WareHouse.Application.Products.Models;

namespace WareHouse.Api.Controllers;

[ApiController]
[Route("api/products")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;
    private readonly IMapper _mapper;

    public ProductsController(
        IProductsService productsService,
        IMapper mapper)
    {
        _productsService = productsService;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetProducts")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync()
    {
        var products = await _productsService.GetAllAsync();
        var productDtos = products.Select(_mapper.Map<ProductDto>).ToList();
        return Ok(productDtos);
    }

    [HttpGet("{departmentId}", Name = "GetProductsByDepartmentId")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByDepartmentIdAsync(int departmentId)
    {
        var products = await _productsService.GetByDepartmentIdAsync(departmentId);
        var productDtos = products.Select(_mapper.Map<ProductDto>).ToList();
        return Ok(productDtos);
    }

    [HttpPost(Name = "CreateProduct")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<ProductDto>> CreateAsync(ProductDto productDto)
    {
        var product = _mapper.Map < ProductModel>(productDto);
        product = await _productsService.CreateAsync(product);
        productDto = _mapper.Map<ProductDto>(product);
        return Created($"api/departments/{productDto.Id}", productDto);
    }

    [HttpPatch("{id}", Name = "UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status205ResetContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<ProductDto>> UpdateAsync(int id, ProductPatchDto productPatchDto)
    {
        var product = await _productsService.UpdateAsync(id, _mapper.Map<ProductPatchModel>(productPatchDto));
        return Ok(_mapper.Map<ProductDto>(product));
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _productsService.DeleteAsync(id);
        return NoContent();
    }

}
