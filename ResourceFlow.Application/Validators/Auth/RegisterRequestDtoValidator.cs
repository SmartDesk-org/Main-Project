using FluentValidation;
using ResourceFlow.Application.DTOs.Auth;
using System.Text.RegularExpressions;

namespace ResourceFlow.Application.Validators.Auth
{
    public class RegisterRequestDtoValidator
        : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            // ---------------- EMAIL ----------------
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .Must(email => !email.Contains(" "))
                .WithMessage("Email must not contain spaces");

            // ---------------- PASSWORD ----------------
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .Must(ContainUppercase)
                    .WithMessage("Password must contain at least one uppercase letter")
                .Must(ContainLowercase)
                    .WithMessage("Password must contain at least one lowercase letter")
                .Must(ContainDigit)
                    .WithMessage("Password must contain at least one digit")
                .Must(p => !p.Contains(" "))
                    .WithMessage("Password must not contain spaces");

            // ---------------- USERNAME ----------------
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters")
                .Matches(@"^[A-Za-z]+$")
                    .WithMessage("Username must contain only letters")
                .Must(StartWithLetter)
                    .WithMessage("Username must start with a letter");
        }

        // -------- Helper Methods --------
        private bool ContainUppercase(string password)
            => password.Any(char.IsUpper);

        private bool ContainLowercase(string password)
            => password.Any(char.IsLower);

        private bool ContainDigit(string password)
            => password.Any(char.IsDigit);

        private bool StartWithLetter(string userName)
            => !string.IsNullOrEmpty(userName) && char.IsLetter(userName[0]);
    }
}
