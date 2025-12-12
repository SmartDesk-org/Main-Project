using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class CompanySubscription:BaseEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int SubscriptionPlanId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionStatus Status { get; set; }


        public virtual CompanyDetails? Company { get; set; }
        public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
