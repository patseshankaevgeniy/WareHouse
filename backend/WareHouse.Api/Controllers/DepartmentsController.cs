using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Departments;
using WareHouse.Application.Departments.Models;

namespace WareHouse.Api.Controllers
{
    [ApiController]
    [Route("api/departments")]
    [Produces("application/json")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(
            IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet(Name = "GetDepartments")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAsync()
        {
            var userWords = await _departmentsService.GetAllAsync();
            return Ok(userWords);
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<ActionResult<DepartmentDto>> GetAsync(int id)
        {
            var departmentDto = await _departmentsService.GetAsync(id);
            return Ok(departmentDto);
        }

        [HttpPost(Name = "CreateDepartment")]
        public async Task<ActionResult<DepartmentDto>> CreateAsync(DepartmentDto departmentDto)
        {
            departmentDto = await _departmentsService.CreateAsync(departmentDto);
            return Created($"api/departments/{departmentDto.Id}", departmentDto);
        }

        [HttpDelete("{id}", Name = "DeleteDepartment")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _departmentsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
