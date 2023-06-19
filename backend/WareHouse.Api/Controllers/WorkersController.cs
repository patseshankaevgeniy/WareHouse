using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Workers;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Api.Controllers
{
    [ApiController]
    [Route("api/workers")]
    [Produces("application/json")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersService _workersService;

        public WorkersController(
            IWorkersService workersService)
        {
            _workersService = workersService;
        }

        [HttpGet(Name = "GetWorkers")]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetAsync()
        {
            var workers = await _workersService.GetAllAsync();
            return Ok(workers);
        }

        [HttpGet("{id}", Name = "GetWorker")]
        public async Task<ActionResult<WorkerDto>> GetAsync(int id)
        {
            var workerDto = await _workersService.GetAsync(id);
            return Ok(workerDto);
        }

        [HttpPost(Name = "CreateWorker")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorkerDto))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorDto))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiErrorDto))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrorDto))]
        public async Task<ActionResult<WorkerDto>> CreateAsync(WorkerDto workerDto)
        {
            workerDto = await _workersService.CreateAsync(workerDto);
            return Created($"api/workers/{workerDto.Id}", workerDto);
        }

        [HttpDelete("{id}", Name = "DeleteWorker")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _workersService.DeleteAsync(id);
            return NoContent();
        }
    }
}
