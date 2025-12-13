using FluentValidation;
using ResourceFlow.Domain.Entities.Authorization;

public class PermissionValidator : AbstractValidator<Permission>
{
    public PermissionValidator()
    {
        RuleFor(x => x.ModuleId)
            .GreaterThan(0).WithMessage("ModuleId must be greater than zero");

        RuleFor(x => x.Action)
            .NotEmpty().WithMessage("Action is required")
            .MaximumLength(50).WithMessage("Action cannot exceed 50 characters");
    }
}
