using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class Subscription:BaseEntity
    {
        public int Id { get; set; }
        public string SubscriptionName { get; set; } = null!;

        public int EmployeeLimit { get; set; }
        public int FloorLimit { get; set; }
        public int DeskLimit { get; set; }
        public int MeetingRoomLimit { get; set; }
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

        public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; }  = new List<CompanySubscription>();

    }
}
