using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Authorization
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext _context;

        public PermissionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasPermission(int userId, ModuleCode module, PermissionAction action)
        {
            // 1. Fetch the user with role
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return false;

            // 2. Get permissions for this role and module
            var permission = await _context.RolePermissions
                .Where(rp => rp.RoleId == user.RoleId && rp.ModuleCode == module)
                .Select(rp => new
                {
                    rp.View,
                    rp.Add,
                    rp.Edit,
                    rp.Delete
                })
                .FirstOrDefaultAsync();

            if (permission == null) return false;

            // 3. Return the proper permission based on action
            return action switch
            {
                PermissionAction.View => permission.View,
                PermissionAction.Add => permission.Add,
                PermissionAction.Edit => permission.Edit,
                PermissionAction.Delete => permission.Delete,
                _ => false
            };
        }

        // Optional: check parent module permissions (if you have hierarchical modules)
        public async Task<bool> HasPermissionWithParent(int userId, ModuleCode module, PermissionAction action)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return false;

            // Get the module and all its parents
            var modulesToCheck = await _context.Modules
                .Where(m => m.Code == module)
                .SelectMany(m => GetModuleAndParents(m))
                .ToListAsync();

            foreach (var m in modulesToCheck)
            {
                var permission = await _context.RolePermissions
                    .Where(rp => rp.RoleId == user.RoleId && rp.ModuleCode == m.Code)
                    .Select(rp => new { rp.View, rp.Add, rp.Edit, rp.Delete })
                    .FirstOrDefaultAsync();

                if (permission != null)
                {
                    bool allowed = action switch
                    {
                        PermissionAction.View => permission.View,
                        PermissionAction.Add => permission.Add,
                        PermissionAction.Edit => permission.Edit,
                        PermissionAction.Delete => permission.Delete,
                        _ => false
                    };

                    if (allowed) return true;
                }
            }

            return false;
        }

        // Helper: recursively get module and all its parents
        private IQueryable<AppModule> GetModuleAndParents(AppModule module)
        {
            var modules = _context.Modules.Where(m => m.Id == module.Id);
            if (module.ParentId.HasValue)
            {
                var parent = _context.Modules.Where(m => m.Id == module.ParentId.Value);
                modules = modules.Concat(GetModuleAndParents(parent.FirstOrDefault()));
            }
            return modules;
        }
    }
}
