using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions
{
    public sealed class GracePeriodViolationException : SubscriptionException
    {
        public GracePeriodViolationException()
            : base("Operation not allowed during grace period.") { }
    }

}
