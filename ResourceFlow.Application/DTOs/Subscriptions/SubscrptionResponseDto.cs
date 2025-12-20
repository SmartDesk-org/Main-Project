using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Subscription
{
    public class SubscrptionResponseDto
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; }
        public int EmployeeLimit { get; set; }
        public int FloorLimit { get; set; }
        public int DeskLimit { get; set; }
        public int MeetingRoomLimit { get; set; }
        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
