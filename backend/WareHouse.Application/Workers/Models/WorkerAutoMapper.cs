using AutoMapper;
using System.Linq;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Workers.Models
{
    public class WorkerAutoMapper : Profile
    {
        public WorkerAutoMapper()
        {
            CreateMap<Worker, WorkerModel>()
                .ForMember(x => x.Departments, o => o.MapFrom(w => w.Departments.Select(d => d.Name)))
                .ReverseMap();
        }
    }
}
