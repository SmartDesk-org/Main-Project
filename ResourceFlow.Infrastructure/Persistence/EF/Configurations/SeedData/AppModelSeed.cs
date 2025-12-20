using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Enums.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    internal class AppModelSeed : IEntityTypeConfiguration<AppModule>
    {
         
    
        public void Configure(EntityTypeBuilder<AppModule> builder)
        {
                        builder.HasData(
                    new AppModule { Id = 1, Name = "User Management", Code = ModuleCode.User },
                    new AppModule { Id = 2, Name = "Company Details", Code = ModuleCode.CompanyDetails },
                    new AppModule { Id = 3, Name = "Company Floor", Code = ModuleCode.CompanyFloor, ParentId = 2 },
                    new AppModule { Id = 4, Name = "Resource Management", Code = ModuleCode.Resource },
                    new AppModule { Id = 5, Name = "Employee Management", Code = ModuleCode.Employee },
                    new AppModule { Id = 6, Name = "Subscription Plan", Code = ModuleCode.Subscription }
                );

        }
    }
}
