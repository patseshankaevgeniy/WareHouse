using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Application.Workers;

public interface IWorkersService
{
    Task<List<WorkerDto>> GetAllAsync();
    Task<WorkerDto> GetAsync(int id);
    Task<WorkerDto> CreateAsync(WorkerDto word);
    Task DeleteAsync(int id);
}
