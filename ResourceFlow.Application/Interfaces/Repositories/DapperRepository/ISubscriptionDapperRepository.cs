using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface ISubscriptionDapperRepository
    {
        Task<Subscription?> GetByIdAsync(int subscriptionId);
    }
}
