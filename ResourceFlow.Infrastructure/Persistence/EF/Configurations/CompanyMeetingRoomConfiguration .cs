using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;

public class CompanyMeetingRoomConfiguration
    : IEntityTypeConfiguration<CompanyMeetingRoom>
{
    public void Configure(EntityTypeBuilder<CompanyMeetingRoom> builder)
    {
        builder.ToTable("company_meeting_rooms");

        builder.HasKey(x => x.RoomId);

        builder.Property(x => x.RoomName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Status)
               .HasConversion<string>()
               .IsRequired();

        builder.Property(x => x.SpecificationsJson)
               .HasColumnType("nvarchar(max)");

        // ==============================
        // Company → MeetingRooms (1:N)
        // ==============================
        builder.HasOne(x => x.Company)
               .WithMany(c => c.MeetingRooms)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

        // ==============================
        // Floor → MeetingRooms (1:N)
        // ==============================
        builder.HasOne(x => x.Floor)
               .WithMany(f => f.MeetingRooms)
               .HasForeignKey(x => x.FloorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.CompanyId, x.Status });
    }
}
