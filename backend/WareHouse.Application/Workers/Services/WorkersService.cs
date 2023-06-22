using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Exceptions;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Workers.Models;
using WareHouse.Domain.Entities;
using ValidationException = WareHouse.Application.Common.Exceptions.ValidationException;

namespace WareHouse.Application.Workers;

public class WorkersService : IWorkersService
{
    private readonly IGenericRepository<Worker> _workerRepository;
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkerModel> _validator;

    public WorkersService(
        IGenericRepository<Worker> workerRepository,
        IGenericRepository<Department> departmentRepository,
        IMapper mapper,
        IValidator<WorkerModel> validator)
    {
        _workerRepository = workerRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<WorkerModel> GetAsync(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var worker = await _workerRepository.GetAsync(id);
        if (worker == null)
        {
            return null;
        }

        return _mapper.Map<WorkerModel>(worker);
    }

    public async Task<List<WorkerModel>> GetAllAsync()
    {
        var workers = await _workerRepository.GetAllAsync(x => x.Include(d => d.Departments));

        return workers.Select(_mapper.Map<WorkerModel>).ToList();
    }

    public async Task<WorkerModel> CreateAsync(int departmentId, WorkerModel workerDto)
    {
        var result = _validator.Validate(workerDto);
        if (!result.IsValid)
        {
            throw new ValidationException(result.ToString());
        }
        var worker = await _workerRepository.FirstAsync(x => x.FirstName == workerDto.FirstName && x.LastName == workerDto.LastName);

        if (worker == null)
        {
            var department = await _departmentRepository.FirstAsync(x => x.Id == departmentId);
            worker = new Worker
            {
                FirstName = workerDto.FirstName,
                LastName = workerDto.LastName,
                Departments = new List<Department> { department }
            };
            worker = await _workerRepository.CreateAsync(worker);
        }

        return _mapper.Map<WorkerModel>(worker);
    }

    public async Task<WorkerModel> UpdateAsync(int id, WorkerPatchModel workerPatchDto)
    {
        var worker = await _workerRepository.FirstAsync(x => x.Id == id, x => x.Include(d => d.Departments));
        if (worker == null)
        {
            throw new NotFoundException($"Can't find worker with id: {id}");
        }

        if (workerPatchDto.FirstName != null && workerPatchDto.LastName != null)
        {
            if (worker.FirstName != workerPatchDto.FirstName || worker.LastName != workerPatchDto.LastName)
            {
                worker.FirstName = workerPatchDto.FirstName;
                worker.LastName = workerPatchDto.LastName;
                await _workerRepository.UpdateAsync(worker);
            }
        }

        return _mapper.Map<WorkerModel>(worker);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new ValidationException("Id can't be less or equal zero");
        }

        var worker = await _workerRepository.GetAsync(id);
        if (worker == null)
        {
            throw new NotFoundException($"Can't find worker with id: {id}");
        }

        await _workerRepository.DeleteAsync(worker);
    }
}
