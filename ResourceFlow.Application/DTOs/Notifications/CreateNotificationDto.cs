using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Notifications
{
    public class CreateNotificationDto
    {
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }

        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 500 characters")]
        public string Message { get; set; }

        [Required(ErrorMessage = "NotificationType is required")]
        public NotificationType NotificationType { get; set; }

        [Required(ErrorMessage = "TargetChannel is required")]
        public TargetChannel TargetChannel { get; set; }

        [Required(ErrorMessage = "ReferenceType is required")]
        public ReferenceType? ReferenceType { get; set; }

        [Required(ErrorMessage = "ReferenceId is required")]
        public int? ReferenceId { get; set; }

        public bool SendImmediately { get; set; } = true;
    }
}
