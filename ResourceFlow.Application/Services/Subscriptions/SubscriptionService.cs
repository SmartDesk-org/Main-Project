using AutoMapper;
using Npgsql.Internal;
using ResourceFlow.Application.Interfaces.Repositories;

using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Application.Interfaces.Subscriptions;

namespace ResourceFlow.Application.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IGenericRepository<Subscription> _repo;
        private readonly ISubscriptionPlanDapperRepository _dapperRepo;
        private readonly IMapper _mapper;

        public SubscriptionService(IGenericRepository<Subscription> repo,
            ISubscriptionPlanDapperRepository dapperRepo,
            IMapper mapper)
        {
            _repo = repo;
            _dapperRepo = dapperRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Subscription>> CreatePlanAsync(CreateSubscriptionPlanDto dto, int userId)
        {
            var exists = await _repo.SingleOrDefaultAsync(x => x.SubscriptionName == dto.SubscriptionName && x.IsDeleted==false);
            if (exists != null)
                return new ApiResponse<Subscription>(400, "Plan already exists");

            var plan = _mapper.Map<Subscription>(dto);
            await _repo.AddAsync(plan);
            return new ApiResponse<Subscription>(200, "Plan created succesfully", plan);
        }

        public async Task<ApiResponse<IEnumerable<Subscription>>> GetAllPlansAsync()
        {
            try
            {
                var res = await _dapperRepo.GetAllAsync();
                if (res == null || !res.Any())
                    return new ApiResponse<IEnumerable<Subscription>>(404, "Subscription plans not configured");
                return new ApiResponse<IEnumerable<Subscription>>(200, "Plans fetched succesfully", res);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Subscription>>(500, ex.Message);
            }
          
        }

        public async Task<ApiResponse<Subscription>?> GetPlanByIdAsync(int id)
        {
            var res= await _repo.GetByIdAsync(id);
            if (res == null)
                return new ApiResponse<Subscription>(404, "Plan not found");
            return new ApiResponse<Subscription>(200, "Plan fetched successfully", res);
        }

        public async Task<Response<Object>> UpdatePlanAsync(UpdateSubscriptionPlanDto dto, int userId,int planId)
        {
            var existing = await _repo.GetByIdAsync(planId);
            if (existing == null) return new Response<Object>(400, "Plan doesnt exist");

            var duplicate =await  _repo.SingleOrDefaultAsync(x => x.SubscriptionName == dto.SubscriptionName && x.Id!=planId&& x.IsDeleted == false);
            if (duplicate != null)
                return new Response<Object>(409, "Alredy there is a plan with this name");

             _mapper.Map(dto,existing);
            Console.WriteLine("________________________________");
            Console.WriteLine("from update");
            Console.WriteLine(existing.MaxEmployees);

            await _repo.UpdateAsync(existing);
            return new Response<Object>(200, "Plan updated successfully", existing);
        }

        public async Task<ApiResponse<bool>> DeletePlanAsync(int id,int userId)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return new ApiResponse<bool>(400, "Plan doesnt exist");
            await _repo.DeleteAsync(item);
            return new ApiResponse<bool>(200, "Plan deleted ");
        }

        public async Task<Response<object>> ChangeStatusAsync(int planId, int userId)
        {
            var plan = await _repo.GetByIdAsync(planId);

            if (plan == null || plan.IsDeleted)
                return new Response<object>(404, "Plan not found");

            if (plan.IsActive)
                plan.IsActive = false;
            else
                plan.IsActive = true;

            await _repo.UpdateAsync(plan);

            return new Response<object>(200, "Status changed successfully");
        }

       

    }
}
