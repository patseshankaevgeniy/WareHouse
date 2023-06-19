using FluentValidation;

namespace WareHouse.Application.Departments.Models
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
