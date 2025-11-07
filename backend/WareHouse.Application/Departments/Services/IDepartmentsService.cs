using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Departments.Models;

namespace WareHouse.Application.Departments
{
    public interface IDepartmentsService
    {
        Task<List<DepartmentModel>> GetAllAsync();
        Task<DepartmentModel> GetAsync(int id);
        Task<DepartmentModel> CreateAsync(DepartmentModel word);
        Task<DepartmentModel> UpdateAsync(int departmentId, DepartmentPatchModel departmentPatchModel);
        Task DeleteAsync(int id);
    }
}
