using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Enums.Authorization;
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
                        new RolePermission {  RoleId = 1, ModuleCode = ModuleCode.User, View = true, Add = true, Edit = true, Delete = true },
                        new RolePermission {RoleId = 1, ModuleCode = ModuleCode.Subscription, View = true, Add = true, Edit = true, Delete = true },
                        new RolePermission {  RoleId = 2, ModuleCode = ModuleCode.User, View = true, Add = true, Edit = true, Delete = false },
                        new RolePermission { RoleId = 2, ModuleCode = ModuleCode.Subscription, View = true, Add = false, Edit = false, Delete = false }

         );

        }
    }
}
