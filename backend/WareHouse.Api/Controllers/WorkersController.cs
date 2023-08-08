using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Api.Dtos;
using WareHouse.Api.Dtos.Workers;
using WareHouse.Application.Common.Models;
using WareHouse.Application.Workers;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Api.Controllers;

[ApiController]
[Route("api/workers")]
[Produces("application/json")]
public class WorkersController : ControllerBase
{
    private readonly IWorkersService _workersService;
    private readonly IMapper _mapper;

    public WorkersController(
        IWorkersService workersService,
        IMapper mapper)
    {
        _workersService = workersService;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWorkers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorkerDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<WorkerDto>>> GetAsync()
    {
        var workers = await _workersService.GetAllAsync();
        return Ok(workers.Select(_mapper.Map<WorkerDto>).ToList());
    }

    [HttpGet("{id}", Name = "GetWorker")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkerDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<WorkerDto>> GetAsync(int id)
    {
        var worker = await _workersService.GetAsync(id);
        return Ok(_mapper.Map<WorkerDto>(worker));
    }

    [HttpPost("{departmentId}", Name = "CreateWorker")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorkerDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<WorkerDto>> CreateAsync(int departmentId, CreateWorkerDto createWorkerDto)
    {
        var worker = await _workersService.CreateAsync(departmentId, _mapper.Map<WorkerModel>(createWorkerDto));
        var workerDto = _mapper.Map<WorkerDto>(worker);
        return Created($"api/workers/{workerDto.Id}", workerDto);
    }

    [HttpPatch("{id}", Name = "UpdateWorker")]
    [ProducesResponseType(StatusCodes.Status205ResetContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult<WorkerDto>> UpdateAsync(int id, WorkerPatchDto workerPatchDto)
    {
        var worker = await _workersService.UpdateAsync(id, _mapper.Map<WorkerPatchModel>(workerPatchDto));
        return Ok(_mapper.Map<WorkerDto>(worker));
    }

    [HttpDelete("{id}", Name = "DeleteWorker")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _workersService.DeleteAsync(id);
        return NoContent();
    }
}
