
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;

namespace ResourceFlow.Application.Interfaces.Subscription
{
    public interface ISubscriptionService
    {
        Task<ApiResponse<SubscriptionPlan>> CreatePlanAsync(CreateSubscriptionPlanDto dto,int userId);
        Task<ApiResponse<IEnumerable<SubscriptionPlan>>> GetAllPlansAsync();
        Task<ApiResponse<SubscriptionPlan>?> GetPlanByIdAsync(int id);
        Task<ApiResponse<bool>> UpdatePlanAsync(UpdateSubscriptionPlanDto dto,int userId);
        Task<ApiResponse<bool>> DeletePlanAsync(int id,int userId);
    }
}
