using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Subscription
{
    public class UpdateSubscriptionPlanDto
    {
        public string SubscriptionName { get; set; } = null!;

        public int MaxEmployees { get; set; }
        public int MaxFloors { get; set; }
        public int MaxDesks { get; set; }
        public int MaxMeetingRooms { get; set; }
        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TypeId { get; set; }


      
       
    }
}
