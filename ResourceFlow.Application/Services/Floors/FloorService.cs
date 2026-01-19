using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.Interfaces.Floors;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Floors
{
    public class FloorService : IFloorService
    {
        private readonly ISubscriptionValidationService _validator;
        private readonly IGenericRepository<CompanyFloor> _floorRepo;
        private readonly IFloorDapperRepository _floorDapperRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<FloorService> _logger;
        private readonly IUserDapperRepository _userDapperRepo;
        private readonly ICompanyDapperRepository _companyDapperRepo;

        public FloorService(
            ISubscriptionValidationService validator,
            IGenericRepository<CompanyFloor> floorRepo,
            IUserDapperRepository userDapperRepo,
            IFloorDapperRepository floorDapperRepo,
            IMapper mapper,
            ICompanyDapperRepository companyDapperRepo,
            ILogger<FloorService> logger
        )
        {
            _validator = validator;
            _floorRepo = floorRepo;
            _floorDapperRepo = floorDapperRepo;
            _mapper = mapper;
            _logger = logger;
            _userDapperRepo = userDapperRepo;
            _companyDapperRepo = companyDapperRepo;
        }

        public async Task<Response<CompanyFloor>> CreateFloorAsync(CreateFloorDto dto,int userId)
        {
            

            try
            {
                int companyId =await  _userDapperRepo.GetCompanyId(userId);

                var isCompanyAdmin = await _companyDapperRepo
                     .IsUserCompanyAdminAsync(userId, companyId);

                if (!isCompanyAdmin)
                    throw new UnauthorizedAccessException(
                        "User is not admin of this company"
                    );

                _logger.LogInformation(
                "CreateFloorAsync started. CompanyId: {CompanyId}",
                companyId
            );
                _logger.LogInformation(
                    "Validating subscription for floor creation. CompanyId: {CompanyId}",
                    companyId
                );

                await _validator.ValidateAsync(
                    companyId,
                    SubscriptionFeature.Floor,
                    SubscriptionAction.Create
                );

                var floor = _mapper.Map<CompanyFloor>(dto);
                floor.IsActive = true;
                floor.CompanyId = companyId;


                var existing = await _floorRepo.SingleOrDefaultAsync(x => x.CompanyId==companyId && x.FloorName.ToLower().Trim() == dto.FloorName.ToLower().Trim() && x.IsActive == true && x.IsDeleted == false);
                if (existing != null)
                    return new Response<CompanyFloor>(409, "Already a floor exist with this name ");
                existing = await _floorRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.FloorNumber == dto.FloorNumber && x.IsActive == true && x.IsDeleted == false);
                if (existing != null)
                    return new Response<CompanyFloor>(409, "Already a floor exist with this floor number ");

                var newFloor = await _floorRepo.AddAsync(floor);

                _logger.LogInformation(
                    "Floor created successfully. FloorId: {FloorId}, CompanyId: {CompanyId}",
                    newFloor.FloorId,
                    companyId
                );

                return new Response<CompanyFloor>(
                    201,

                    "Floor Added succseesfully",

                    newFloor
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating floor. CompanyId: "
                );
                throw;
            }
        }

        public async Task<Response<IEnumerable<FloorDto>>> GetFloorsAsync(int userId)
        {
            _logger.LogInformation(
                "GetFloorsAsync started. CompanyId: {userId}",
                userId
            );

            try
            {
                Console.WriteLine("__________________");Console.WriteLine($"from floor service userId :{userId}" );
                var companyId = await _userDapperRepo.GetCompanyId(userId);
                Console.WriteLine("__________________"); Console.WriteLine($"from floor service companyId :{companyId}");
                var floors = await _floorDapperRepo.GetFloorsAsync(companyId  );

                if (floors == null || !floors.Any())
                {
                    _logger.LogWarning(
                        "No floors found for company. CompanyId: {CompanyId}",
                        userId
                    );

                    return new Response<IEnumerable<FloorDto>>(
                        400,
                        "NormalizationForm floors found"
                    );
                }

                _logger.LogInformation(
                    "Floors fetched successfully. CompanyId: {CompanyId}, Count: {Count}",
                    companyId,
                    floors.Count()
                );

                return new Response<IEnumerable<FloorDto>>(
                    200,
                    "Floors fetched successfully",floors
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching floors"
                    
                );
                throw;
            }
        }
    }
}
