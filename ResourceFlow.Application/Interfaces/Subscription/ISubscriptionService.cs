using ResourceFlow.Application.DTO.Subscription;
using ResourceFlow.Domain.Entities.Subscription;

namespace ResourceFlow.Application.Interfaces.Subscription
{
    public interface ISubscriptionService
    {
        Task<int> CreatePlanAsync(CreateSubscriptionDto dto);
        Task<List<Plan>> GetAllPlansAsync();
        Task<Plan?> GetPlanByIdAsync(int id);
        Task<bool> UpdatePlanAsync(UpdateSubscriptionDto dto);
        Task<bool> DeletePlanAsync(int id);
    }
}
