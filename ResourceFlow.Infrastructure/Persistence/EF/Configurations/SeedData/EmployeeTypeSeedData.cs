using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    public class EmployeeTypeSeedData : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.HasData(
                new EmployeeType { EmployeeTypeId = 1, TypeName = "JuniorDeveloper" },
                new EmployeeType { EmployeeTypeId = 2, TypeName = "MidLevelDeveloper" },
                new EmployeeType { EmployeeTypeId = 3, TypeName = "SeniorDeveloper" },
                new EmployeeType { EmployeeTypeId = 4, TypeName = "LeadDeveloper" },
                new EmployeeType { EmployeeTypeId = 5, TypeName = "TeamLead" },
                new EmployeeType { EmployeeTypeId = 6, TypeName = "DevelopmentManager"},
                new EmployeeType { EmployeeTypeId = 7, TypeName = "ProjectManager"},
                new EmployeeType { EmployeeTypeId = 8, TypeName = "SoftwareArchitect" },
                new EmployeeType { EmployeeTypeId = 9, TypeName = "QAEngineer" },
                new EmployeeType { EmployeeTypeId = 10, TypeName = "DevOpsEngineer" }
            );
        }
    }
}