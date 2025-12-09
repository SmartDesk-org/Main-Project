using ResourceFlow.Application.DTO.Subscription;
using ResourceFlow.Application.Interfaces.Subscription;
using ResourceFlow.Domain.Entities.Subscription;



namespace ResourceFlow.Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repo;

        public SubscriptionService(ISubscriptionRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreatePlanAsync(CreateSubscriptionDto dto)
        {
            var plan = new Plan
            {
                Name = dto.Name,
                MaxEmployees = dto.MaxEmployees,
                MaxDesks = dto.MaxDesks,
                MaxMeetingRooms = dto.MaxMeetingRooms,
                MaxCheckinsPerDay = dto.MaxCheckinsPerDay,
                ExpiryType = dto.ExpiryType,
                PlanType = dto.PlanType
            };

            return await _repo.AddAsync(plan);
        }

        public async Task<List<Plan>> GetAllPlansAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Plan?> GetPlanByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> UpdatePlanAsync(UpdateSubscriptionDto dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.MaxEmployees = dto.MaxEmployees;
            existing.MaxDesks = dto.MaxDesks;
            existing.MaxMeetingRooms = dto.MaxMeetingRooms;
            existing.MaxCheckinsPerDay = dto.MaxCheckinsPerDay;
            existing.ExpiryType = dto.ExpiryType;
            existing.PlanType = dto.PlanType;

            return await _repo.UpdateAsync(existing);
        }

        public async Task<bool> DeletePlanAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
