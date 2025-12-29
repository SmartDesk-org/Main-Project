using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface IResourceUsageDapperRepository
    {
        Task<int> GetCountAsync(int companyId, SubscriptionFeature feature);
    }
}
