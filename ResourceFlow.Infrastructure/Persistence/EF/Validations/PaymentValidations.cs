
using FluentValidation;
using ResourceFlow.Domain.Entities.Finance;

namespace ResourceFlow.Application.Validators.Finance
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CompanyId)
                .GreaterThan(0)
                .WithMessage("CompanyId must be a valid ID.");

            //RuleFor(x => x.SubscriptionId)
            //    .GreaterThan(0)
            //    .WithMessage("SubscriptionId must be a valid ID.");

            //RuleFor(x => x.TransactionId)
            //    .NotEmpty()
                //.WithMessage("TransactionId is required.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PaymentStatus)
                .NotEmpty()
                .WithMessage("PaymentStatus is required.");

            RuleFor(x => x.PaymentDate)
                .NotEmpty()
                .WithMessage("PaymentDate is required.");
        }
    }
}
