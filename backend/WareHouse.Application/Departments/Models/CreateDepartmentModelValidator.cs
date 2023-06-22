using FluentValidation;

namespace WareHouse.Application.Departments.Models;

public class CreateDepartmentModelValidator : AbstractValidator<CreateDepartmentModel>
{
    public CreateDepartmentModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
