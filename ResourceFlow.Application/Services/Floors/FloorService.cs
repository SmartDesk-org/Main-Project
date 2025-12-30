using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.Interfaces.Floors;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
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

        public FloorService(
            ISubscriptionValidationService validator,
            IGenericRepository<CompanyFloor> floorRepo,
            IFloorDapperRepository floorDapperRepo,
            IMapper mapper,
            ILogger<FloorService> logger
        )
        {
            _validator = validator;
            _floorRepo = floorRepo;
            _floorDapperRepo = floorDapperRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<CompanyFloor>> CreateFloorAsync(CreateFloorDto dto)
        {
            _logger.LogInformation(
                "CreateFloorAsync started. CompanyId: {CompanyId}",
                dto.CompanyId
            );

            try
            {
                _logger.LogInformation(
                    "Validating subscription for floor creation. CompanyId: {CompanyId}",
                    dto.CompanyId
                );

                await _validator.ValidateAsync(
                    dto.CompanyId,
                    SubscriptionFeature.Floor,
                    SubscriptionAction.Create
                );

                var floor = _mapper.Map<CompanyFloor>(dto);
                floor.IsActive = true;

                var newFloor = await _floorRepo.AddAsync(floor);

                _logger.LogInformation(
                    "Floor created successfully. FloorId: {FloorId}, CompanyId: {CompanyId}",
                    newFloor.FloorId,
                    dto.CompanyId
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
                    "Error occurred while creating floor. CompanyId: {CompanyId}",
                    dto.CompanyId
                );
                throw;
            }
        }

        public async Task<Response<IEnumerable<FloorDto>>> GetFloorsAsync(int companyId)
        {
            _logger.LogInformation(
                "GetFloorsAsync started. CompanyId: {CompanyId}",
                companyId
            );

            try
            {
                var floors = await _floorDapperRepo.GetFloorsAsync(companyId);

                if (floors == null || !floors.Any())
                {
                    _logger.LogWarning(
                        "No floors found for company. CompanyId: {CompanyId}",
                        companyId
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
                    "Floors fetched successfully"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching floors. CompanyId: {CompanyId}",
                    companyId
                );
                throw;
            }
        }
    }
}
