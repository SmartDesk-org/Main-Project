using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
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
        // ✅ 1. FIRST CHECK: AllowAnonymous ALWAYS wins
        if (HasAllowAnonymous(context))
            return;

        // ✅ 2. Require authentication
        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // ✅ 3. Extract UserId
        var userIdClaim = context.HttpContext.User.FindFirst("UserId");
        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // ✅ 4. Check module permission
        var permissionService = context.HttpContext.RequestServices
            .GetRequiredService<IPermissionService>();

        bool allowed = await permissionService
            .HasModulePermission(userId, _module, _action);

        if (!allowed)
            context.Result = new ForbidResult();
    }

    private bool HasAllowAnonymous(AuthorizationFilterContext context)
    {
        // Check both action and controller for [AllowAnonymous]
        var endpoint = context.HttpContext.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            return true;

        // Fallback: check filters
        return context.Filters.Any(f => f is IAllowAnonymousFilter);
    }
}