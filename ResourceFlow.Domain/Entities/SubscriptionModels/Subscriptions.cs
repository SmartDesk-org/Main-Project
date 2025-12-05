using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class Subscriptions:BaseEntity
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; } = null!;

        public int ResourceId { get; set; }

        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;

        public Resource? Resource { get; set; }
        public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; }  = new List<CompanySubscription>();

    }
}
