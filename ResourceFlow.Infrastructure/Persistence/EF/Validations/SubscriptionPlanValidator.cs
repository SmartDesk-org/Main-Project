using FluentValidation;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class SubscriptionPlanValidator :AbstractValidator<CreateSubscriptionPlanDto>
    {
        public SubscriptionPlanValidator()
        {
            RuleFor(s => s.SubscriptionPlanName)
                .NotEmpty().WithMessage("Subscription name is required.")
                .MaximumLength(100).WithMessage("Subscription name cannot exceed 100 characters.");

            //RuleFor(s => s.ResourceId)
            //    .GreaterThan(0).WithMessage("Subscription must reference a valid resource.");

            RuleFor(s => s.PriceMonthly)
                .GreaterThanOrEqualTo(0).WithMessage("Monthly price must be non-negative.");

            RuleFor(s => s.PriceYearly)
                .GreaterThanOrEqualTo(0).WithMessage("Yearly price must be non-negative.");

            RuleFor(s => s.PriceMonthly)
                .LessThan(s => s.PriceYearly)
                .WithMessage("Monthly price must be less than yearly price.");

            RuleFor(s => s.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
