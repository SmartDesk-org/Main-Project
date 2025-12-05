using FluentValidation;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    internal class ResourceValidator:AbstractValidator<Resource>
    {
        public ResourceValidator()
        {
            RuleFor(r => r.ResourceName)
                .NotEmpty().WithMessage("Resource name is required.")
                .MaximumLength(100).WithMessage("Resource name cannot exceed 100 characters.");

            RuleFor(r => r.IsActive)
                .NotNull().WithMessage("Resource active status must be specified.");
        }
    }
}
