using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employees>
    {
       
     public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e=>e.Id);
            builder.Property(e => e.Status).HasDefaultValue(EmployeeStatus.Active);
        }
    }
}
