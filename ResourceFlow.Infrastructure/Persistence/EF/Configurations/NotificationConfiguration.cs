using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");
        // TITLE
        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(200);

        // MESSAGE
        builder.Property(n => n.Message)
            .IsRequired();

        // ENUM CONVERSIONS (Store enums as strings)
        builder.Property(n => n.NotificationType)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(n => n.TargetChannel)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(n => n.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(n => n.ReferenceType)
            .HasConversion<string>()
            .HasMaxLength(50);

        // OPTIONAL FIELDS
        builder.Property(n => n.ReferenceId)
            .IsRequired(false);

        builder.Property(n => n.SentAt)
            .IsRequired(false);

        builder.Property(n => n.ReadAt)
            .IsRequired(false);

        builder.Property(n => n.IsSent)
            .HasDefaultValue(false);

        builder.Property(n => n.IsRead)
            .HasDefaultValue(false);

        builder.Property(n => n.RetryCount)
            .HasDefaultValue(0);

        // RELATIONSHIPS

        // Company (nullable)
        builder.HasOne(n => n.Company)
            .WithMany()
            .HasForeignKey(n => n.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);

       
        builder.HasOne(n => n.User)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(n => n.Role)
            .WithMany()
            .HasForeignKey(n => n.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
