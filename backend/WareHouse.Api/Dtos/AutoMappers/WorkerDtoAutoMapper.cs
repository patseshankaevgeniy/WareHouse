using AutoMapper;
using WareHouse.Api.Dtos.Workers;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Api.Dtos.AutoMappers;

public class WorkerDtoAutoMapper : Profile
{
    public WorkerDtoAutoMapper()
    {
        CreateMap<WorkerModel, WorkerDto>().ReverseMap();
        CreateMap<WorkerPatchModel, WorkerPatchDto>().ReverseMap();
        CreateMap<CreateWorkerDto, WorkerModel>().ReverseMap();
    }
}
