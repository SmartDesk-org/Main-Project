using FluentValidation;
using ResourceFlow.Application.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Validations
{
    public  class NewCompanyValidator:AbstractValidator<NewCompanyDto>
    {
        public NewCompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(100).WithMessage("Name should less than 100 chars");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(250).WithMessage("Name should less than 250 chars");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email is required.")
                 .EmailAddress().WithMessage("Invalid email format.")
                 .MaximumLength(150).WithMessage("Email cannot exceed 150 characters.")
                 .Must(email => !email.Contains(" ")).WithMessage("Email cannot contain spaces.")
                 .Must(email => !email.StartsWith(".")).WithMessage("Email cannot start with a dot.")
                 .Must(email => !email.EndsWith(".")).WithMessage("Email cannot end with a dot.")
                 .Must(email => !email.Contains("..")).WithMessage("Email cannot contain consecutive dots.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.PassWord)
                .WithMessage("Pass word does not match");

            

            RuleFor(x => x)
                .Must(x =>
                (x.ExpirationYear == 1 && x.ExpirationMonth == 0) ||
                (x.ExpirationYear == 0 && x.ExpirationMonth >= 1 && x.ExpirationMonth <= 11)
                )
                .WithMessage("Select either 1 year OR 1–11 months");
        }
    }
}
