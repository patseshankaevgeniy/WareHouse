using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Application.Workers.Models;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Workers;

public class WorkersService : IWorkersService
{
    private readonly IGenericRepository<Worker> _workerRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkerDto> _validator;

    public WorkersService(
        IGenericRepository<Worker> workerRepository,
        IMapper mapper,
        IValidator<WorkerDto> validator)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<WorkerDto> GetAsync(int id)
    {
        if (id <= 0)
        {

        }

        var worker = await _workerRepository.GetAsync(id);
        if (worker == null)
        {
            return null;
        }

        return _mapper.Map<WorkerDto>(worker);
    }

    public async Task<List<WorkerDto>> GetAllAsync()
    {
        var workers = await _workerRepository.GetAllAsync();

        return workers.Select(_mapper.Map<WorkerDto>).ToList();
    }

    public async Task<WorkerDto> CreateAsync(WorkerDto workerDto)
    {
        var result = _validator.Validate(workerDto);
        if (!result.IsValid)
        {

        }

        var worker = new Worker
        {
            FirstName = workerDto.FirstName,
            LastName = workerDto.LastName,
            Login = "Login",
            Password = "Password"
        };

        worker = await _workerRepository.CreateAsync(worker);
        return _mapper.Map<WorkerDto>(worker);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
        }

        var worker = await _workerRepository.GetAsync(id);

        if (worker == null)
        {
        }

        await _workerRepository.DeleteAsync(worker);
    }
}
