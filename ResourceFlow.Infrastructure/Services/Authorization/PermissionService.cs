using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<bool> HasPermission(int userId, string moduleName, string action)
        {
            var permission = await _context.RolePermissions
                .Include(rp => rp.Module)
                .Include(rp => rp.Role)
                .Where(rp => rp.Role.Users.Any(u => u.UserId == userId) &&
                             rp.Module.Name == moduleName)
                .Select(rp => new { rp.CanAdd, rp.CanEdit, rp.CanView, rp.CanDelete })
                .FirstOrDefaultAsync();

            if (permission == null) return false;

            return action switch
            {
                "Add" => permission.CanAdd,
                "Edit" => permission.CanEdit,
                "View" => permission.CanView,
                "Delete" => permission.CanDelete,
                _ => false
            };
        }
    }


}
