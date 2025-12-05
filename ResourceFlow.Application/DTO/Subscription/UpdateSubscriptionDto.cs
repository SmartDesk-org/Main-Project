using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTO.Subscription
{
    public class UpdateSubscriptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxEmployees { get; set; }
        public int MaxDesks { get; set; }
        public int MaxMeetingRooms { get; set; }
        public int MaxCheckinsPerDay { get; set; }
        public string ExpiryType { get; set; }
        public string PlanType { get; set; }
    }
}
