using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Validators.Auth
{
    public static class PasswordValidator
    {
        public static IRuleBuilderOptions<T, string> StrongPassword<T>(
           this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .Must(p => p.Any(char.IsUpper))
                    .WithMessage("Password must contain at least one uppercase letter")
                .Must(p => p.Any(char.IsLower))
                    .WithMessage("Password must contain at least one lowercase letter")
                .Must(p => p.Any(char.IsDigit))
                    .WithMessage("Password must contain at least one digit")
                .Must(p => !p.Contains(" "))
                    .WithMessage("Password must not contain spaces");
        }
    }
}

