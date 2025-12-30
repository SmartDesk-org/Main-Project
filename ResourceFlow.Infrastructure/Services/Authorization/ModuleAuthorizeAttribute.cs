using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Authorization;
using System;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Services.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ModuleAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ModuleCode _module;
        private readonly PermissionAction _action;
        private readonly PermissionScope? _explicitScope; // Optional explicit scope

        // Constructor: Scope is now optional (defaults to inferred from route)
        public ModuleAuthorizeAttribute(ModuleCode module, PermissionAction action, PermissionScope scope = default)
        {
            _module = module;
            _action = action;
            _explicitScope = scope == default ? null : scope; // Null if not provided
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // 1. Check if user is authenticated
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // 2. Get UserId from claims
            var userIdClaim = context.HttpContext.User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            int userId = int.Parse(userIdClaim.Value);

            // 3. Resolve PermissionService from DI
            var permissionService = context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();

            // 4. Infer scope if not explicitly provided
            PermissionScope scope = _explicitScope ?? InferScopeFromRoute(context);

            // 5. Extract targetId if scope is OWN
            int? targetId = null;
            if (scope == PermissionScope.OWN)
            {
                if (context.RouteData.Values["id"] is string idStr && int.TryParse(idStr, out int parsedId))
                {
                    targetId = parsedId;
                }
                else
                {
                    // Fallback: Assume self-access if no ID (e.g., /api/employees/me endpoint)
                    targetId = userId;
                }
            }

            // 6. Check scoped permission
            bool hasPermission = await permissionService.HasScopePermission(userId, _module, _action, targetId, scope);
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }

        // Helper: Infer scope based on route (e.g., presence of {id} param)
        private PermissionScope InferScopeFromRoute(AuthorizationFilterContext context)
        {
            // Check for common single-record route params (e.g., "id", "employeeId")
            var routeValues = context.RouteData.Values;
            if (routeValues.ContainsKey("id") || routeValues.ContainsKey("employeeId") || routeValues.ContainsKey("userId"))
            {
                return PermissionScope.OWN; // Infer single-record access
            }

            // Default to full access for list/collection endpoints
            return PermissionScope.ALL;
        }
    }
}