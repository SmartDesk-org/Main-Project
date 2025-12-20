using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public  class SubscriptionType:BaseEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public ICollection<Subscription> Types { get; set; } = new List<Subscription>();
    }
}
