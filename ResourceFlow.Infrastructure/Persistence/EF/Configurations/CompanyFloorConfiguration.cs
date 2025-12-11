using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public  class CompanyFloorConfiguration:IEntityTypeConfiguration<CompanyFloor>
    {
        public void Configure(EntityTypeBuilder<CompanyFloor> builder)
        {
            builder.ToTable("CompanyFloors");

            builder.HasKey(u => u.FloorId);

            builder.HasOne(u => u.Company)
                .WithMany(u => u.CompanyFloors)
                .HasForeignKey(u => u.CompanyId)
                .IsRequired(false);
        }
    }
}
