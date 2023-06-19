using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Products;
using WareHouse.Application.Products.Models;

namespace WareHouse.Api.Controllers;

[ApiController]
[Route("api/products")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(
        IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync()
    {
        var products = await _productsService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> GetAsync(int id)
    {
        var productDto = await _productsService.GetAsync(id);
        return Ok(productDto);
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<ProductDto>> CreateAsync(ProductDto productDto)
    {
        productDto = await _productsService.CreateAsync(productDto);
        return Created($"api/departments/{productDto.Id}", productDto);
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _productsService.DeleteAsync(id);
        return NoContent();
    }

}
