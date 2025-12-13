using FluentValidation;
using ResourceFlow.Domain.Entities.Authorization;

public class RolePermissionValidator : AbstractValidator<RolePermission>
{
    public RolePermissionValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("RoleId must be greater than zero");

        RuleFor(x => x.PermissionId)
            .GreaterThan(0).WithMessage("PermissionId must be greater than zero");
    }
}
