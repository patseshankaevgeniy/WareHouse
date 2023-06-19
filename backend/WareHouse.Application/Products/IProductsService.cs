using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Products.Models;

namespace WareHouse.Application.Products;

public interface IProductsService
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetAsync(int id);
    Task<ProductDto> CreateAsync(ProductDto word);
    Task DeleteAsync(int id);
}
