using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Api.Dtos;
using WareHouse.Application.Common.Models;
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
        private readonly IMapper _mapper;

        public DepartmentsController(
            IDepartmentsService departmentsService,
             IMapper mapper)
        {
            _departmentsService = departmentsService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DepartmentDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAsync()
        {
            var departments = await _departmentsService.GetAllAsync();
            return Ok(departments.Select(_mapper.Map<DepartmentDto>).ToList());
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepartmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public async Task<ActionResult<DepartmentDto>> GetAsync(int id)
        {
            var department = await _departmentsService.GetAsync(id);
            return Ok(_mapper.Map<DepartmentDto>(department));
        }

        [HttpPost(Name = "CreateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepartmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public async Task<ActionResult<DepartmentDto>> CreateAsync(DepartmentDto departmentDto)
        {
           var department = await _departmentsService.CreateAsync(_mapper.Map<DepartmentModel>(departmentDto));
            departmentDto = _mapper.Map<DepartmentDto>(department);
            return Created($"api/departments/{departmentDto.Id}", departmentDto);
        }

        [HttpPatch("{id}", Name = "UpdateDepartment")]
        [ProducesResponseType(StatusCodes.Status205ResetContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public async Task<ActionResult<DepartmentDto>> UpdateAsync(int id, DepartmentPatchDto departmentPatchDto)
        {
            var department = await _departmentsService.UpdateAsync(id, _mapper.Map<DepartmentPatchModel>(departmentPatchDto));
            return Ok(_mapper.Map<DepartmentDto>(department));
        }

        [HttpDelete("{id}", Name = "DeleteDepartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _departmentsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
