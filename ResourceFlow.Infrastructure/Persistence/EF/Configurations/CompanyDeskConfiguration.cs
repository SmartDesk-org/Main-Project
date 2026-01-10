using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class CompanyDeskConfiguration : IEntityTypeConfiguration<CompanyDesk>
    {
        public void Configure(EntityTypeBuilder<CompanyDesk> builder)
        {
            builder.ToTable("CompanyDesks");

            builder.HasKey(x => x.DeskId);

            // Add this for Name property (missing in your code)
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(x => x.SpecificationsJson)
                   .HasColumnType("nvarchar(max)")
                   .IsRequired();

            builder.Property(x => x.XPosition)
                   .IsRequired();

            builder.Property(x => x.YPosition)
                   .IsRequired();

            // Company relationship
            builder.HasOne(x => x.Company)
                   .WithMany(c => c.Desks)
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔥 FIXED: Floor relationship - Cascade ആക്കുക
            builder.HasOne(x => x.Floor)
                   .WithMany(f => f.Desks)
                   .HasForeignKey(x => x.FloorId)
                   .OnDelete(DeleteBehavior.Cascade); // RESTRICT → CASCADE

            builder.HasIndex(x => new { x.CompanyId, x.Status });
            builder.HasIndex(x => new { x.FloorId, x.XPosition, x.YPosition }); // For drag-drop queries
        }
    }
}