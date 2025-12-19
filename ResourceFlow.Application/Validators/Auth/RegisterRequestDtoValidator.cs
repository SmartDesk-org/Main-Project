using FluentValidation;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Validators.Auth;

namespace ResourceFlow.Application.Validators.Auth
{
    public class RegisterRequestDtoValidator
        : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(e => !e.Contains(" "))
                .WithMessage("Email must not contain spaces");

            RuleFor(x => x.Password)
                .StrongPassword();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .Length(3, 50)
                .Matches(@"^[A-Za-z]+$")
                .WithMessage("Username must contain only letters")
                .Must(u => char.IsLetter(u[0]))
                .WithMessage("Username must start with a letter");
        }
    }
}
