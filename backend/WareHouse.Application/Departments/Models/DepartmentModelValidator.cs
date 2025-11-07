using FluentValidation;

namespace WareHouse.Application.Departments.Models
{
    public class DepartmentModelValidator : AbstractValidator<DepartmentModel>
    {
        public DepartmentModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
