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
                  new RolePermission { RoleId = 1, ModuleCode = SPS, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = RLS, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = NOT, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = CDS, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = CUS, Add = false, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = EMP, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = BIL, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = PAY, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = USR, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = DSK, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = FLR, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = MRM, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = CLM, Add = false, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 1, ModuleCode = SHI, Add = false, Edit = false, Delete = false,View = true  },
                  new RolePermission { RoleId = 1, ModuleCode = STY ,Add = true,  Edit = true, Delete = true, View = true},
                  new RolePermission { RoleId = 1, ModuleCode = RES ,Add = true, Edit = true, Delete = true,View = true},

                  // ------------------- Company Admin -------------------
                  new RolePermission { RoleId = 2, ModuleCode = SPS, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = CDS, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = CUS, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = EMP, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = BIL, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = PAY, Add = true, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = USR, Add = true, Edit = true, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = DSK, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = FLR, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = MRM, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = NOT, Add = true, Edit = true, Delete = true, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = RLS, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 2, ModuleCode = CLM, Add = true,  Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = SHI, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = STY, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 2, ModuleCode = RES, Add = true, Edit = true, Delete = true, View = true },

                  // ------------------- Employees -------------------
                  new RolePermission { RoleId = 3, ModuleCode = SPS, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = CDS, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = CUS, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = EMP, Add = false, Edit = true, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = BIL, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = PAY, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = USR, Add = false, Edit = true, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = DSK, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = FLR, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = MRM, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = NOT, Add = false, Edit = false, Delete = false, View = true },
                  new RolePermission { RoleId = 3, ModuleCode = RLS, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = CLM, Add = false, Edit = false, Delete = false, View = false},
                  new RolePermission { RoleId = 3, ModuleCode = SHI, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = STY, Add = false, Edit = false, Delete = false, View = false },
                  new RolePermission { RoleId = 3, ModuleCode = RES, Add = false, Edit = false, Delete = false, View = false }
              );

        }
    }
}
