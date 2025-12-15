using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    internal class RolePermissionSeed : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
                    builder.HasData(
             new RolePermission { Id = 1, RoleId = 1, ModuleId = 6, CanAdd = true, CanEdit = true, CanView = true, CanDelete = true },
             new RolePermission { Id = 2, RoleId = 2, ModuleId = 6, CanAdd = false, CanEdit = false, CanView = true, CanDelete = false },
             new RolePermission { Id = 3, RoleId = 3, ModuleId = 6, CanAdd = false, CanEdit = false, CanView = false, CanDelete = false }
         );

        }
    }
}
