using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Products.Models;

namespace WareHouse.Application.Products;

public interface IProductsService
{
    Task<List<ProductModel>> GetAllAsync();
    Task<List<ProductModel>> GetByDepartmentIdAsync(int id);
    Task<ProductModel> CreateAsync(ProductModel word);
    Task<ProductModel> UpdateAsync(int id, ProductPatchModel productPatchDto);
    Task DeleteAsync(int id);
}
