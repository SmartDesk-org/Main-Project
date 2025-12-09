using FluentValidation;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public class CompanySubscriptionValidator:AbstractValidator<CompanySubscription>
    {
        public CompanySubscriptionValidator()
        {
            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("CompanyId must be a positive integer.");

            
            RuleFor(x => x.SubscriptionId)
                .GreaterThan(0)
                .WithMessage("SubscriptionId must be a positive integer.");

          
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("StartDate is required.")
                .LessThan(x => x.EndDate)
                .WithMessage("StartDate must be earlier than EndDate.");

         
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("EndDate is required.")
                .GreaterThan(x => x.StartDate)
                .WithMessage("EndDate must be greater than StartDate.");

           
            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("IsActive must be provided.");

           RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid subscription status.");
        }
    }
}
