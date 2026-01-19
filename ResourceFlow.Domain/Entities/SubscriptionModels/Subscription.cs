using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public partial class Subscription:BaseEntity
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; } = null!;

        public int MaxEmployees { get; set; }
        public int MaxFloors { get; set; }
        public int MaxDesks { get; set; }
        public int MaxMeetingRooms { get; set; }
        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TypeId { get; set; }

        [NotMapped]
        public SubscriptionTypeEnum TypeEnum
        {
            get=> (SubscriptionTypeEnum)TypeId;
            set => TypeId = (int)value;
        }
        public SubscriptionType? Type { get; set; }

        public bool IsActive { get; set; } = true;
        public int GracePeriodDays { get; set; }

        public int GetLimit(SubscriptionFeature feature)
        {
            return feature switch
            {
                SubscriptionFeature.Desk => MaxDesks,
                SubscriptionFeature.Floor => MaxFloors,
                SubscriptionFeature.Employee => MaxEmployees,
                SubscriptionFeature.MeetingRoom => MaxMeetingRooms,
                _ => 0
            };
        }


        public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; }  = new List<CompanySubscription>();

    }

    public partial class Subscription
    {
        public bool IsInGracePeriod(DateTime subscriptionEndDate)
        {
            if (GracePeriodDays <= 0)
                return false;

            var graceEndDate = subscriptionEndDate.AddDays(GracePeriodDays);
            return DateTime.UtcNow <= graceEndDate;
        }
    }
}
