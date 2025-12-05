using ResourceFlow.Domain.Entities.Subscription;

namespace ResourceFlow.Application.Interfaces.Subscription
{
    public interface ISubscriptionRepository
    {
        Task<int> AddAsync(Plan entity);
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Plan entity);
        Task<bool> DeleteAsync(int id);
    }
}
