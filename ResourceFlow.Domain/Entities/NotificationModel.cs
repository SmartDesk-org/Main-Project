using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Enums;

public class Notification : BaseEntity
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public int RoleId { get; set; }

    public string Title { get; set; }
    public string Message { get; set; }

    // ENUMS (FINAL)
    public NotificationType NotificationType { get; set; }
    public TargetChannel TargetChannel { get; set; }
    public NotificationStatus Status { get; set; }
    public ReferenceType? ReferenceType { get; set; }

    public int? ReferenceId { get; set; }

    public DateTime? SentAt { get; set; }
    public bool IsSent { get; set; }

    public DateTime? ReadAt { get; set; }
    public bool IsRead { get; set; }

    public int RetryCount { get; set; } = 0;

    // NAVIGATION (enable later)
    public CompanyDetails Company { get; set; }
    public User User { get; set; }
    public Roles Role { get; set; }
}
