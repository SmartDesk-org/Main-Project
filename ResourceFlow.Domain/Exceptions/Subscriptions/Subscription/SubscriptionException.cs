using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Exceptions.Subscriptions.Subscription
{
    public class SubscriptionException: Exception
    {
                
            protected SubscriptionException(string message) : base(message) { }
        
    }
}
