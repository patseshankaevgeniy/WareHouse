using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Exceptions;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Departments.Models;
using WareHouse.Domain.Entities;
using ValidationException = WareHouse.Application.Common.Exceptions.ValidationException;

namespace WareHouse.Application.Departments;

public class DepartmentsService : IDepartmentsService
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DepartmentModel> _validator;

    public DepartmentsService(
        IGenericRepository<Department> departmentRepository,
        IMapper mapper,
        IValidator<DepartmentModel> validator)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<DepartmentModel> GetAsync(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var department = await _departmentRepository.FirstAsync(x => x.Id == id);

        if (department == null)
        {
            throw new NotFoundException($"Can't find department with id: {id}");
        }

        return _mapper.Map<DepartmentModel>(department);
    }

    public async Task<List<DepartmentModel>> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync(x => x.Include(y => y.Products).Include(y => y.Workers));

        return departments.Select(_mapper.Map<DepartmentModel>).ToList();
    }

    public async Task<DepartmentModel> CreateAsync(DepartmentModel departmentDto)
    {
        var result = _validator.Validate(departmentDto);
        if (!result.IsValid)
        {
            throw new ValidationException(result.ToString());
        }

        var department = new Department
        {
            Name = departmentDto.Name,
        };

        department = await _departmentRepository.CreateAsync(department);
        return _mapper.Map<DepartmentModel>(department);
    }

    public async Task<DepartmentModel> UpdateAsync(int departmentId, DepartmentPatchModel departmentPatchModel)
    {
        var department = await _departmentRepository
            .FirstAsync(
                x => x.Id == departmentId,
                x => x.Include(y => y.Products)
                      .Include(y => y.Workers));
        if (department == null)
        {
            throw new NotFoundException($"Can't find department with id: {departmentId}");
        }

        if (department.Name != departmentPatchModel.Name)
        {
            department.Name = departmentPatchModel.Name;
            await _departmentRepository.UpdateAsync(department);
        }

        return _mapper.Map<DepartmentModel>(department);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var department = await _departmentRepository.GetAsync(id);

        if (department == null)
        {
            throw new NotFoundException($"Can't find department with id: {id}");
        }

        await _departmentRepository.DeleteAsync(department);
    }
}
