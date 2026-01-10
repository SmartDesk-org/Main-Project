using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities.CompanyModels;



namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class CompanySubscription:BaseEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionStatus Status { get; set; }


        public virtual CompanyDetails Company { get; set; }
        public virtual Subscriptions Subscription { get; set; }
    }
}
