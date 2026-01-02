using AutoMapper;
using Npgsql.Internal;
using ResourceFlow.Application.Interfaces.Repositories;

using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Application.Interfaces.Subscriptions;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;

namespace ResourceFlow.Application.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IGenericRepository<Domain.Entities.SubscriptionModels.Subscription> _repo;
        private readonly IGenericRepository<SubscriptionType> _typeRepo;
        private readonly ISubscriptionDapperRepository _dapperRepo;
        private readonly ILogger<SubscriptionService> _logger;
        private readonly IMapper _mapper;

        public SubscriptionService(IGenericRepository<Domain.Entities.SubscriptionModels.Subscription> repo,
            ISubscriptionDapperRepository dapperRepo,
            IGenericRepository<SubscriptionType> typeRepo,
            ILogger<SubscriptionService> logger,
            IMapper mapper)
        {
            _repo = repo;
            _typeRepo = typeRepo;
            _dapperRepo = dapperRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Domain.Entities.SubscriptionModels.Subscription>> CreatePlanAsync(CreateSubscriptionPlanDto dto, int userId)
        {
            var exists = await _repo.SingleOrDefaultAsync(x => x.SubscriptionName == dto.SubscriptionName && x.IsDeleted==false);
            if (exists != null)
                return new ApiResponse<Domain.Entities.SubscriptionModels.Subscription>(400, "Plan already exists");

            var plan = _mapper.Map<Domain.Entities.SubscriptionModels.Subscription>(dto);
            var existType =await  _typeRepo.SingleOrDefaultAsync(u => u.Id == plan.TypeId);
            if (existType == null)
                throw new Exception("Invalid plan type");

            var similarPlanExists = await _repo.SingleOrDefaultAsync(x =>
                                     x.TypeId == dto.TypeId &&
                                     x.MaxEmployees == dto.MaxEmployees &&
                                    x.MaxFloors == dto.MaxFloors &&
                                    x.MaxDesks == dto.MaxDesks &&
                                    x.MaxMeetingRooms == dto.MaxMeetingRooms &&
                                    x.PriceMonthly == dto.PriceMonthly &&
                                    x.PriceYearly == dto.PriceYearly &&
                                    x.IsDeleted == false
                                                 );

            if (similarPlanExists != null)
                return new ApiResponse<Domain.Entities.SubscriptionModels.Subscription>(
                    400,
                    "A similar subscription plan already exists"
                );

            await _repo.AddAsync(plan);
            return new ApiResponse<Domain.Entities.SubscriptionModels.Subscription>(200, "Plan created succesfully", plan);
        }

        public async Task<ApiResponse<IEnumerable<SubscriptionResponseDto>>> GetAllPlansAsync()
        {
            try
            {
                var sub = await _dapperRepo.GetAllAsync();
                _logger.LogInformation("sub {data}", sub.First().Description);
                if (sub == null || !sub.Any())
                    return new ApiResponse<IEnumerable<SubscriptionResponseDto>>(404, "Subscription plans not configured");
                //var res = _mapper.Map<IEnumerable<SubscriptionResponseDto>>(sub);

                return new ApiResponse<IEnumerable<SubscriptionResponseDto>>(200, "Plans fetched succesfully", sub);

            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<SubscriptionResponseDto>>(500, ex.Message);
            }
          
        }

        public async Task<ApiResponse<Domain.Entities.SubscriptionModels.Subscription>?> GetPlanByIdAsync(int id)
        {
            var res= await _repo.GetByIdAsync(id);
            if (res == null)
                return new ApiResponse<Domain.Entities.SubscriptionModels.Subscription>(404, "Plan not found");
            return new ApiResponse<Domain.Entities.SubscriptionModels.Subscription>(200, "Plan fetched successfully", res);
        }

        public async Task<Response<Object>> UpdatePlanAsync(UpdateSubscriptionPlanDto dto, int userId,int planId)
        {
            var existing = await _repo.GetByIdAsync(planId);
            if (existing == null) return new Response<Object>(400, "Plan doesnt exist");

            var duplicate =await  _repo.SingleOrDefaultAsync(x => x.SubscriptionName == dto.SubscriptionName && x.Id!=planId&& x.IsDeleted == false);
            if (duplicate != null)
                return new Response<Object>(409, "Alredy there is a plan with this name");

            var similarPlanExists = await _repo.SingleOrDefaultAsync(x =>
                                            x.Id != planId &&
                                            x.TypeId == dto.TypeId &&
                                            x.MaxEmployees == dto.MaxEmployees &&
                                            x.MaxFloors == dto.MaxFloors &&
                                            x.MaxDesks == dto.MaxDesks &&
                                            x.MaxMeetingRooms == dto.MaxMeetingRooms &&
                                            x.PriceMonthly == dto.PriceMonthly &&
                                            x.PriceYearly == dto.PriceYearly &&
                                            x.IsDeleted == false
                                                 );

            if (similarPlanExists != null)
                return new Response<object>(
                    409,
                    "Another subscription plan with the same configuration already exists"
                );
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

       public async Task<Response<IEnumerable<SubscriptionType>>> GetAllSubscriptionTypes()
        {
            var res = await _typeRepo.GetAllAsync();
            if (res == null || !res.Any())
                return new Response<IEnumerable<SubscriptionType>>(404, "No Type Found ");
            return new Response<IEnumerable<SubscriptionType>>(200, "Types fetched successfully", res);
        }

    }
}
