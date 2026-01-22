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
        public  int Id { get; set; }
        public int CompanyId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public double AmoutToBePaid { get; set; }
        public bool IsActive { get; set; }

        public int UpcomingComSubId { get; set; } = 0;
        public SubscriptionStatus Status { get; set; }

        public int EmployeesLimit { get; set; }
        public int FloorsLimit { get; set; }
        public int DesksLimit { get; set; }
        public int MeetingRoomsLimit { get; set; }


        public virtual CompanyDetails? Company { get; set; }
        public virtual Subscription? Subscription { get; set; }

        public bool IsExpired(DateTime now)
           => EndDate < now;

        public bool IsInGracePeriod(DateTime now)
        {
            if (Subscription == null)
                return false;

            var graceEnd = EndDate.AddDays(Subscription.GracePeriodDays);
            return now > EndDate && now <= graceEnd;
        }

        public bool IsValid(DateTime now)
            => now >= StartDate && now <= EndDate;


    }
}

