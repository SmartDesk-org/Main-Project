using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class Resource:BaseEntity
    {
        public int Id { get; set; }
        public string ResourceName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Subscriptions>? Subscriptions { get; set; }
    }
}
