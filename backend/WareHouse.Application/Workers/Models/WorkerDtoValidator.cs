using FluentValidation;

namespace WareHouse.Application.Workers.Models
{
    internal class WorkerDtoValidator : AbstractValidator<WorkerDto>
    {
        public WorkerDtoValidator()
        {
            RuleFor(x=> x.FirstName).NotEmpty();
            RuleFor(x=> x.LastName).NotEmpty();
        }
    }
}
