using AutoMapper;
using System.Linq;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Departments.Models;

public class DepartmentAutoMapper : Profile
{
    public DepartmentAutoMapper()
    {
        CreateMap<Department, DepartmentModel>()
            .ForMember(x => x.Products, o => o.MapFrom(p => p.Products.Select(t => t.Name)))
            .ForMember(x => x.Workers, o => o.MapFrom(w => w.Workers.Select(t => t.FirstName + " " + t.LastName)))
            .ReverseMap();
    }
}
