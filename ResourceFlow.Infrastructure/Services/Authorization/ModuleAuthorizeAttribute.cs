using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Domain.Enums.Authorization;


namespace ResourceFlow.Infrastructure.Services.Authorization
{
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
            // 🔑 Respect [AllowAnonymous]
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata
                .Any(em => em is AllowAnonymousAttribute);

            if (allowAnonymous)
                return;

            // Existing logic
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

            int? resourceId = null;
            if (context.RouteData.Values.TryGetValue("id", out var idObj) &&
                int.TryParse(idObj?.ToString(), out int parsedId))
            {
                resourceId = parsedId;
            }

            var permissionService =
                context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();

            bool isAllowed =
                await permissionService.HasScopePermission(userId, _module, _action, resourceId);

            if (!isAllowed)
                context.Result = new ForbidResult();
        }


    }
}
