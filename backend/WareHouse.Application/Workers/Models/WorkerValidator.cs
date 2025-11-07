using FluentValidation;

namespace WareHouse.Application.Workers.Models
{
    internal class WorkerValidator : AbstractValidator<WorkerModel>
    {
        public WorkerValidator()
        {
            RuleFor(x=> x.FirstName).NotEmpty();
            RuleFor(x=> x.LastName).NotEmpty();
        }
    }
}
