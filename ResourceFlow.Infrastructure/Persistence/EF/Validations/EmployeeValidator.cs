using FluentValidation;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    internal class EmployeeValidator:AbstractValidator<Employees>
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
                .NotEmpty().WithMessage("DefaultFloorId is required")
                .GreaterThanOrEqualTo(0).WithMessage("DefaultFloorId must be 0 or greater");

            RuleFor(e => e.Department)
                .NotEmpty().WithMessage("Department is required")
                .MaximumLength(100).WithMessage("Department name cannot exceed 100 characters");

            RuleFor(e => e.Status)
                .IsInEnum().WithMessage("Invalid employee status");

            RuleFor(e => e.User)
                .NotNull().WithMessage("User navigation property cannot be null");

            RuleFor(e => e.Company)
                .NotNull().WithMessage("Company navigation property cannot be null");      
        }
    }
}
