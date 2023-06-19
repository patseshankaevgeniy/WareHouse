using AutoMapper;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Workers.Models
{
    public class WorkerAutoMapper : Profile
    {
        public WorkerAutoMapper()
        {
            CreateMap<Worker, WorkerDto>().ReverseMap();
        }
    }
}
