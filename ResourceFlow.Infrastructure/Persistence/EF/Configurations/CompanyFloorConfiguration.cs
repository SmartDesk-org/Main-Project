using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{

       public class CompanyFloorConfiguration
           : IEntityTypeConfiguration<CompanyFloor>
       {
              public void Configure(EntityTypeBuilder<CompanyFloor> builder)
              {
                     builder.ToTable("CompanyFloors");

                     builder.HasKey(x => x.FloorId);

                     builder.Property(x => x.FloorName)
                            .IsRequired()
                            .HasMaxLength(100);

                     builder.Property(x => x.FloorNumber)
                            .IsRequired();

                     builder.Property(x => x.Map)
                            .HasColumnType("nvarchar(max)")   // ✅ SQL Server compatible
                            .IsRequired();

                     builder.Property(x => x.IsActive)
                            .HasDefaultValue(true);

                     builder.HasOne(x => x.Company)
                            .WithMany(x => x.CompanyFloors)
                            .HasForeignKey(x => x.CompanyId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.HasIndex(x => new { x.CompanyId, x.IsActive });
              }
       }
}
