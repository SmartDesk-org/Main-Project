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
    public class ResourceConfiguration:IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.ResourceName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasOne(r => r.Company)
                   .WithMany(s => s.Resources)
                   .HasForeignKey(s => s.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);
            // ✅ QR Code properties
            builder.Property(r => r.QRCodeValue)
                   .IsRequired()
                   .HasMaxLength(100); // Guid string length

            builder.Property(r => r.QRCodeImage)
                   .HasColumnType("nvarchar(max)"); // Base64 image

            builder.HasOne(r => r.Floor)
                .WithMany(f => f.Resources)
                .HasForeignKey(r => r.FloorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.ResourceType)
                .WithMany(t => t.Resources)
                .HasForeignKey(r => r.ResourceTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.CompanyId, x.FloorId });
            builder.HasIndex(x => new { x.CompanyId, x.ResourceTypeId });
        }
    }
}
