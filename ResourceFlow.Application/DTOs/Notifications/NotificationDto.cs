using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Notifications
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public int RoleId { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public NotificationType NotificationType { get; set; }
        public TargetChannel TargetChannel { get; set; }
        public NotificationStatus Status { get; set; }
        public ReferenceType? ReferenceType { get; set; }

        public int? ReferenceId { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public bool IsRead { get; set; }
        public bool IsSent { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Additional info for UI
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}
