using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    public class companyResourceBookingPermissionsSeedData: IEntityTypeConfiguration<CompanyResourceBookingPermission>
    {

        public void Configure(EntityTypeBuilder<CompanyResourceBookingPermission> builder)
        {

            builder.HasData(new CompanyResourceBookingPermission
            {
                Id = 1,
                CompanyId = 1,
                ResourceTypeId = 2,
                EmployeeType = "MANAGER",
                CanBook = true
            },
                new CompanyResourceBookingPermission
                {
                    Id = 2,
                    CompanyId = 1,
                    ResourceTypeId = 2,
                    EmployeeType = "TEAM_LEAD",
                    CanBook = true
                });
        }

    }
}
