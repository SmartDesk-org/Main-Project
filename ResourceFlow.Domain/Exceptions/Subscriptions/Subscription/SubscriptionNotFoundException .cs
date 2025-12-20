using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Subscription
{
    namespace ResourceFlow.Domain.Exceptions.Subscriptions.Subscription
    {
        public sealed class SubscriptionNotFoundException : SubscriptionException
        {
            public SubscriptionNotFoundException(int companyId)
                : base($"No active subscription found for company '{companyId}'.") { }
        }
    }

}
