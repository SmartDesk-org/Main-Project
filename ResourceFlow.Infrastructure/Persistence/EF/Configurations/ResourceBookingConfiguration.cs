using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Booking;

public class ResourceBookingConfiguration
    : IEntityTypeConfiguration<ResourceBooking>
{
    public void Configure(EntityTypeBuilder<ResourceBooking> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartTime).IsRequired();
        builder.Property(x => x.EndTime).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.QRCodeValue).IsRequired();
        builder.HasIndex(x => x.QRCodeValue).IsUnique();
        builder.Property(x => x.QrExpiresAt).IsRequired();


        builder.HasOne(x => x.Resource)
               .WithMany()
               .HasForeignKey(x => x.ResourceId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ResourceType)
               .WithMany()
               .HasForeignKey(x => x.ResourceTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CompanyDetails)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        // Critical for overlap checks
        builder.HasIndex(x => new
        {
            x.ResourceId,
            x.StartTime,
            x.EndTime
        });
    }
}
