using AutoMapper;
using WareHouse.Application.Departments.Models;

namespace WareHouse.Api.Dtos.AutoMappers;

public class DepartmentDtoAutoMapper : Profile
{
    public DepartmentDtoAutoMapper()
    {
        CreateMap<DepartmentModel, DepartmentDto>().ReverseMap();
        CreateMap<DepartmentPatchModel, DepartmentPatchDto>().ReverseMap();
    }
}
