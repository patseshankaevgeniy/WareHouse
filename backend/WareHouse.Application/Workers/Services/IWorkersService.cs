using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Application.Workers;

public interface IWorkersService
{
    Task<List<WorkerModel>> GetAllAsync();
    Task<WorkerModel> GetAsync(int id);
    Task<WorkerModel> CreateAsync(int departmentId, WorkerModel worker);
    Task<WorkerModel> UpdateAsync(int id, WorkerPatchModel workerPatchDto);
    Task DeleteAsync(int id);
}
