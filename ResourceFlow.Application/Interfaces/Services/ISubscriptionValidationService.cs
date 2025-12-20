using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface ISubscriptionValidationService
    {

        Task ValidateAsync(int companyId,SubscriptionFeature feature, SubscriptionAction action);
    }
}
