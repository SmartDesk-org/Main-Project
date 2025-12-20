using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions
{
    public sealed class PlanLimitExceededException : SubscriptionException
    {
        public PlanLimitExceededException(string feature)
            : base($"{feature} limit exceeded for current plan.") { }
    }

}
