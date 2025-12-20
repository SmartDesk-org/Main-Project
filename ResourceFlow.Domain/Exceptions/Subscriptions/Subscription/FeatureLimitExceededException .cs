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
        public sealed class FeatureLimitExceededException : SubscriptionException
        {
            public FeatureLimitExceededException(
                SubscriptionFeature feature,
                int limit)
                : base($"Limit exceeded for feature '{feature}'. Allowed maximum is {limit}.") { }
        }
    }

}
