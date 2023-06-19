using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Departments.Models;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Departments;

public class DepartmentsService : IDepartmentsService
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DepartmentDto> _validator;

    public DepartmentsService(
        IGenericRepository<Department> departmentRepository,
        IMapper mapper,
        IValidator<DepartmentDto> validator)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<DepartmentDto> GetAsync(int id)
    {
        if (id <= 0)
        {

        }

        var department = await _departmentRepository.FirstAsync(x => x.Id == id);

        if (department == null)
        {
            return null;
        }

        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<List<DepartmentDto>> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();

        return departments.Select(_mapper.Map<DepartmentDto>).ToList();
    }

    public async Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto)
    {
        var result = _validator.Validate(departmentDto);
        if (!result.IsValid)
        {

        }

        var department = new Department
        {
            Name = departmentDto.Name,
        };

        department = await _departmentRepository.CreateAsync(department);
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {

        }

        var department = await _departmentRepository.GetAsync(id);

        if (department == null)
        {

        }

        await _departmentRepository.DeleteAsync(department);
    }
}
