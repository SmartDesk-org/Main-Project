using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authentication;
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
    internal class AppModelSeed : IEntityTypeConfiguration<AppModule>
    {
         
    
        public void Configure(EntityTypeBuilder<AppModule> builder)
        {                          
                                   builder.HasData(
                new AppModule { Id = 1, Name = "User Management", Code = ModuleCode.USR },

                new AppModule { Id = 2, Name = "Company Details", Code = ModuleCode.CDS },

                new AppModule { Id = 3, Name = "Company Floor", Code = ModuleCode.FLR, ParentId = 2 },
                new AppModule { Id = 4, Name = "Company Desk", Code = ModuleCode.DSK, ParentId = 2 },
                new AppModule { Id = 5, Name = "Company Meeting Room", Code = ModuleCode.MRM, ParentId = 2 },

                new AppModule { Id = 6, Name = "Employee Management", Code = ModuleCode.EMP },

                new AppModule { Id = 7, Name = "Subscription Plans", Code = ModuleCode.SPS },

                new AppModule { Id = 8, Name = "Resource Management", Code = ModuleCode.RES, ParentId = 7 },
                new AppModule { Id = 9, Name = "Subscription Types", Code = ModuleCode.STY, ParentId = 7 },
                new AppModule { Id = 10, Name = "Company Subscriptions", Code = ModuleCode.CUS, ParentId = 7 },

                new AppModule { Id = 11, Name = "Payment", Code = ModuleCode.PAY, ParentId = 10 },
                new AppModule { Id = 12, Name = "Billing", Code = ModuleCode.BIL, ParentId = 10 },
                new AppModule { Id = 13, Name = "Subscription History", Code = ModuleCode.SHI, ParentId = 10 },

                new AppModule { Id = 14, Name = "Notifications", Code = ModuleCode.NOT },

                new AppModule { Id = 15, Name = "Client Messages", Code = ModuleCode.CLM },

                new AppModule { Id=16,Name="Roles",Code=ModuleCode.RLS}
                );


        }
    }
}
