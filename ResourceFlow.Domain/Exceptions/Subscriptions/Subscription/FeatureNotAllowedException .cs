using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Subscription
{
    namespace ResourceFlow.Domain.Exceptions.Subscriptions
    {
        public sealed class FeatureNotAllowedException : SubscriptionException
        {
            public FeatureNotAllowedException(
                SubscriptionFeature feature,
                SubscriptionAction action)
                : base($"Action '{action}' is not allowed for feature '{feature}' under the current plan.") { }
        }
    }

}
