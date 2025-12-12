using AutoMapper;
using Npgsql.Internal;
using ResourceFlow.Application.Interfaces.Repositories;

using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Application.Interfaces.Subscription;

namespace ResourceFlow.Application.Services.Subscription
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IGenericRepository<SubscriptionPlan> _repo;
        private readonly IMapper _mapper;

        public SubscriptionService(IGenericRepository<SubscriptionPlan> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SubscriptionPlan>> CreatePlanAsync(CreateSubscriptionPlanDto dto, int userId)
        {
            var exists = await _repo.SingleOrDefaultAsync(x => x.SubscriptionPlanName == dto.SubscriptionPlanName);
            if (exists != null)
                return new ApiResponse<SubscriptionPlan>(400, "Plan already exists");

            var plan = _mapper.Map<SubscriptionPlan>(dto);
            await _repo.AddAsync(plan);
            return new ApiResponse<SubscriptionPlan>(200, "Plan created succesfully", plan);
        }

        public async Task<ApiResponse<IEnumerable<SubscriptionPlan>>> GetAllPlansAsync()
        {
            var res= await _repo.GetAllAsync();
            if (res == null || !res.Any())
                return new ApiResponse<IEnumerable<SubscriptionPlan>>(400, "No plans found");
            return new ApiResponse<IEnumerable<SubscriptionPlan>>(200, "Plans fetched succesfully", res);
        }

        public async Task<ApiResponse<SubscriptionPlan>?> GetPlanByIdAsync(int id)
        {
            var res= await _repo.GetByIdAsync(id);
            if (res == null)
                return new ApiResponse<SubscriptionPlan>(404, "Plan not found");
            return new ApiResponse<SubscriptionPlan>(200, "Plan fetched successfully", res);
        }

        public async Task<ApiResponse<bool>> UpdatePlanAsync(UpdateSubscriptionPlanDto dto, int userId)
        {
            var existing = await _repo.GetByIdAsync(dto.SubscriptionPlanId);
            if (existing == null) return new ApiResponse<bool>(400, "Plan doesnt exist");

            var duplicate =await  _repo.SingleOrDefaultAsync(x => x.SubscriptionPlanName == dto.SubscriptionPlanName && x.IsDeleted == false);
            if (duplicate != null)
                return new ApiResponse<bool>(409, "Alredy there is a plan with this name");

             _mapper.Map(dto,existing);
            
            await _repo.SaveChangesAsync();
            return new ApiResponse<bool>(200, "Plan updated successfully", true);
        }

        public async Task<ApiResponse<bool>> DeletePlanAsync(int id,int userId)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return new ApiResponse<bool>(400, "Plan doesnt exist");
            await _repo.DeleteAsync(item);
            return new ApiResponse<bool>(200, "Plan deleted ");
        }
    }
}
