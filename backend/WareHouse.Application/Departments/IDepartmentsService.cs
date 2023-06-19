using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Departments.Models;

namespace WareHouse.Application.Departments
{
    public interface IDepartmentsService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> GetAsync(int id);
        Task<DepartmentDto> CreateAsync(DepartmentDto word);
        Task DeleteAsync(int id);
    }
}
