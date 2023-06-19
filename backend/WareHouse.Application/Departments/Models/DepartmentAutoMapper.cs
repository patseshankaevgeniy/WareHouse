using AutoMapper;
using WareHouse.Domain.Entities;

namespace WareHouse.Application.Departments.Models;

public class DepartmentAutoMapper : Profile
{
    public DepartmentAutoMapper()
    {
        CreateMap<Department, DepartmentDto>().ReverseMap();
    }
}
