using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Booking;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class CompanyResourceBookingPermissionConfiguration
        : IEntityTypeConfiguration<CompanyResourceBookingPermission>
    {
        public void Configure(
            EntityTypeBuilder<CompanyResourceBookingPermission> builder)
        {
            builder.ToTable("CompanyResourceBookingPermissions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmployeeType)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.CanBook)
                   .HasDefaultValue(true);

            builder.HasOne(x => x.ResourceType)
                   .WithMany()
                   .HasForeignKey(x => x.ResourceTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Recommended: prevent duplicates
            builder.HasIndex(x => new
            {
                x.CompanyId,
                x.ResourceTypeId,
                x.EmployeeType
            })
            .IsUnique();
        }
    }
}
