using FluentValidation;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class CompanyDeskValidator : AbstractValidator<CompanyDesk>

    {
        public CompanyDeskValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Desk name is required")
                .MaximumLength(50)
                .WithMessage("Desk name cannot exceed 50 characters");

            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("CompanyId is required");

            RuleFor(x => x.FloorId)
                .GreaterThan(0)
                .WithMessage("FloorId is required");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid desk status");

            RuleFor(x => x.XPosition)
                .GreaterThanOrEqualTo(0)
                .WithMessage("X position cannot be negative");

            RuleFor(x => x.YPosition)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Y position cannot be negative");

            RuleFor(x => x.SpecificationsJson)
                .NotNull()
                .WithMessage("SpecificationsJson cannot be null");
        }
    }
    
}

