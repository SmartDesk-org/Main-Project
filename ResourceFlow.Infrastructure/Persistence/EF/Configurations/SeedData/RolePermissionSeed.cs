using DocumentFormat.OpenXml.Office.Word;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Enums.Authorization;
using static ResourceFlow.Domain.Enums.Authorization.ModuleCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    internal class RolePermissionSeed : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {

            builder.HasData(
// ------------------- Super Admin -------------------
new RolePermission { Id = 1, RoleId = 1, UserId = null, ModuleCode = SPS, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 2, RoleId = 1, UserId = null, ModuleCode = RLS, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 3, RoleId = 1, UserId = null, ModuleCode = NOT, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 4, RoleId = 1, UserId = null, ModuleCode = CDS, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 5, RoleId = 1, UserId = null, ModuleCode = STY, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 6, RoleId = 1, UserId = null, ModuleCode = RES, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 7, RoleId = 1, UserId = null, ModuleCode = USR, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 8, RoleId = 1, UserId = null, ModuleCode = APM, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 9, RoleId = 1, UserId = null, ModuleCode = RPM, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 10, RoleId = 1, UserId = null, ModuleCode = CLM, Edit = true, Delete = true, View = true },
new RolePermission { Id = 11, RoleId = 1, UserId = null, ModuleCode = CUS, Edit = true, Delete = true, View = true },
new RolePermission { Id = 12, RoleId = 1, UserId = null, ModuleCode = EMP, View = true },
new RolePermission { Id = 13, RoleId = 1, UserId = null, ModuleCode = BIL, View = true },
new RolePermission { Id = 14, RoleId = 1, UserId = null, ModuleCode = PAY, View = true },
new RolePermission { Id = 15, RoleId = 1, UserId = null, ModuleCode = FLR, View = true },
new RolePermission { Id = 16, RoleId = 1, UserId = null, ModuleCode = SHI, View = true },
new RolePermission { Id = 17, RoleId = 1, UserId = null, ModuleCode = RTY, View = true },
new RolePermission { Id = 18, RoleId = 1, UserId = null, ModuleCode = FBK, View = true },
// ------------------- Company Admin -------------------

new RolePermission { Id = 19, RoleId = 2, UserId = null, ModuleCode = CDS, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 20, RoleId = 2, UserId = null, ModuleCode = FLR, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 21, RoleId = 2, UserId = null, ModuleCode = NOT, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 22, RoleId = 2, UserId = null, ModuleCode = EMP, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 23, RoleId = 2, UserId = null, ModuleCode = RTY, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 24, RoleId = 2, UserId = null, ModuleCode = PAY, Add = true, Edit = true, View = true },
new RolePermission { Id = 25, RoleId = 2, UserId = null, ModuleCode = USR, Add = true, Edit = true, View = true },
new RolePermission { Id = 26, RoleId = 2, UserId = null, ModuleCode = CLM, Add = true, View = true },
new RolePermission { Id = 27, RoleId = 2, UserId = null, ModuleCode = FBK, Add = true, View = true },
new RolePermission { Id = 28, RoleId = 2, UserId = null, ModuleCode = SHI, View = true },
new RolePermission { Id = 29, RoleId = 2, UserId = null, ModuleCode = CUS, View = true },
new RolePermission { Id = 30, RoleId = 2, UserId = null, ModuleCode = BIL, View = true },
new RolePermission { Id = 31, RoleId = 2, UserId = null, ModuleCode = SPS, View = true },
new RolePermission { Id = 32, RoleId = 2, UserId = null, ModuleCode = STY, View = true },
new RolePermission { Id = 42, RoleId = 2, UserId = null, ModuleCode = RBP, Add = true, Edit = true, Delete = true, View = true },
new RolePermission { Id = 43, RoleId = 2, UserId = null, ModuleCode = RBT, Add = true, Edit = true, Delete = true, View = true },

// ------------------- Employees -------------------

new RolePermission { Id = 33, RoleId = 3, UserId = null, ModuleCode = EMP, Edit = true, View = true },
new RolePermission { Id = 34, RoleId = 3, UserId = null, ModuleCode = USR, Edit = true, View = true },
new RolePermission { Id = 35, RoleId = 3, UserId = null, ModuleCode = FBK, Add = true, View = true },
new RolePermission { Id = 36, RoleId = 3, UserId = null, ModuleCode = RTY, View = true },
new RolePermission { Id = 37, RoleId = 3, UserId = null, ModuleCode = CDS, View = true },
new RolePermission { Id = 38, RoleId = 3, UserId = null, ModuleCode = CUS, View = true },
new RolePermission { Id = 39, RoleId = 3, UserId = null, ModuleCode = FLR, View = true },
new RolePermission { Id = 40, RoleId = 3, UserId = null, ModuleCode = NOT, View = true },
new RolePermission { Id = 41, RoleId = 3, UserId = null, ModuleCode = SPS, View = true },
new RolePermission { Id = 44, RoleId = 3, UserId = null, ModuleCode = RBT, Add = true, Edit = true, Delete = true, View = true }
);


        }
    }
}
