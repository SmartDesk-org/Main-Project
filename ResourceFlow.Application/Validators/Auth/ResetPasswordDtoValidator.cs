using FluentValidation;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Validators.Auth;

namespace ResourceFlow.Application.Validators.Auth
{
    public class ResetPasswordDtoValidator
        : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.NewPassword)
                .StrongPassword();
        }
    }
}
