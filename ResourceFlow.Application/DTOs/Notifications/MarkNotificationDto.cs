using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Notifications
{
    public class MarkNotificationDto
    {
        public int NotificationId { get; set; }
    }

    public class MarkMultipleNotificationsDto
    {
        public List<int> NotificationIds { get; set; } = new List<int>();
    }
}
