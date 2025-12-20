using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface ISubscriptionPlanDapperRepository
    {
        Task<IEnumerable<SubscrptionResponseDto>> GetAllAsync();
    }
}
