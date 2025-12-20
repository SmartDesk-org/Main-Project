
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;

namespace ResourceFlow.Application.Interfaces.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<ApiResponse<Subscription>> CreatePlanAsync(CreateSubscriptionPlanDto dto,int userId);
        Task<ApiResponse<IEnumerable<SubscrptionResponseDto>>> GetAllPlansAsync();
        Task<ApiResponse<Subscription>?> GetPlanByIdAsync(int id);
        Task<Response<Object>> UpdatePlanAsync(UpdateSubscriptionPlanDto dto,int userId, int planId);
        Task<ApiResponse<bool>> DeletePlanAsync(int id,int userId);
        Task<Response<object>> ChangeStatusAsync(int planId, int userId);
        Task<Response<IEnumerable<SubscriptionType>>> GetAllSubscriptionTypes();
    }
}
