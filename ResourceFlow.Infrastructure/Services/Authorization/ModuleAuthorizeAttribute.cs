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

        // Constructor now accepts enums instead of string
        public ModuleAuthorizeAttribute(ModuleCode module, PermissionAction action)
        {
            _module = module;
            _action = action;
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
            var permissionService =
                context.HttpContext.RequestServices
                    .GetRequiredService<IPermissionService>();

            // 4. Check permission
            bool hasPermission =
                await permissionService.HasPermission(userId, _module, _action);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
