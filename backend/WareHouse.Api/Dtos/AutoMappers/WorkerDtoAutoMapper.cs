using AutoMapper;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Api.Dtos.AutoMappers;

public class WorkerDtoAutoMapper : Profile
{
    public WorkerDtoAutoMapper()
    {
        CreateMap<WorkerModel, WorkerDto>().ReverseMap();
        CreateMap<WorkerPatchModel, WorkerPatchDto>().ReverseMap();
    }
}
