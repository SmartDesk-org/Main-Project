using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Subscription
{
    public sealed class SubscriptionExpiredException : SubscriptionException
    {
        public SubscriptionExpiredException(int companyId)
            : base($"Subscription for company '{companyId}' has expired.") { }
    }
}
