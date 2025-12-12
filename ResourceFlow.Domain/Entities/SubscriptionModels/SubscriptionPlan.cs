using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class SubscriptionPlan:BaseEntity
    {
        public int Id { get; set; }
        public string SubscriptionPlanName { get; set; } = null!;

        public int EmployeeLimit { get; set; }
        public int FloorLimit { get; set; }
        public int DeskLimit { get; set; }
        public int MeetingRoomLimit { get; set; }
        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; }  = new List<CompanySubscription>();

    }
}
