using FluentValidation;
using ResourceFlow.Domain.Entities.Authorization;

public class AppModuleValidator : AbstractValidator<AppModule>
{
    public AppModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Module name is required")
            .MaximumLength(100).WithMessage("Module name cannot exceed 100 characters");
    }
}
