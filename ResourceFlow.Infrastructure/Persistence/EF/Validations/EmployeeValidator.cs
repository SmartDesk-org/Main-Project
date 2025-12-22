using FluentValidation;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class EmployeeValidator : AbstractValidator<Employees>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(e => e.CompanyId)
                .NotEmpty().WithMessage("CompanyId is required")
                .GreaterThan(0).WithMessage("CompanyId must be greater than 0");

            RuleFor(e => e.DefaultFloorId)
                .GreaterThan(0).WithMessage("DefaultFloorId is required")
                .GreaterThanOrEqualTo(0).WithMessage("DefaultFloorId must be >= 0");

            RuleFor(e => e.Department)
                .NotEmpty().WithMessage("Department is required")
                .MaximumLength(100).WithMessage("Department cannot exceed 100 chars");

            RuleFor(e => e.Status)
                .IsInEnum().WithMessage("Invalid employee status");
        }
    }
}
