using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Domain.Enums.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ModuleAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly ModuleCode _module;
    private readonly PermissionAction _action;

    public ModuleAuthorizeAttribute(ModuleCode module, PermissionAction action)
    {
        _module = module;
        _action = action;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        // Allow anonymous
        if (context.ActionDescriptor.EndpointMetadata
            .Any(m => m is AllowAnonymousAttribute))
            return;

        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userIdClaim = context.HttpContext.User.FindFirst("UserId");
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // ✅ Resolve service here (runtime)
        var permissionService = context.HttpContext
            .RequestServices
            .GetRequiredService<IPermissionService>();

        bool allowed = await permissionService
            .HasModulePermission(userId, _module, _action);

        if (!allowed)
            context.Result = new ForbidResult();
    }
}
