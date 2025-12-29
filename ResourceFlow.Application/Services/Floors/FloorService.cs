using AutoMapper;
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
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Floors
{
    public class FloorService:IFloorService
    {
        private readonly ISubscriptionValidationService _validator;
        private readonly IGenericRepository<CompanyFloor> _floorRepo;
        private readonly IFloorDapperRepository _floorDapperRepo;
        private readonly IMapper _mapper;
        public FloorService(
            ISubscriptionValidationService validator,
            IGenericRepository<CompanyFloor> floorRepo,
            IFloorDapperRepository floorDapperRepo,
            IMapper mapper
            )
        {
            _validator = validator;
            _floorRepo = floorRepo;
            _floorDapperRepo = floorDapperRepo;
            _mapper = mapper;
        }
        public async Task<Response<CompanyFloor>> CreateFloorAsync(CreateFloorDto dto)
        {
            await _validator.ValidateAsync(
                dto.CompanyId,
                SubscriptionFeature.Floor,
                SubscriptionAction.Create
                );
            var floor = _mapper.Map<CompanyFloor>(dto);
            floor.IsActive = true;
            var newFloor=await _floorRepo.AddAsync(floor);
            return new  Response<CompanyFloor>(201, "Floor Added succseesfully", newFloor);
        }
        public async Task<Response<IEnumerable<FloorDto>>> GetFloorsAsync(int companyId)
        {
            var floors = await _floorDapperRepo.GetFloorsAsync(companyId);
            if(floors==null || !floors.Any())
            {
                return new Response<IEnumerable<FloorDto>>(400, "NormalizationForm floors found");

            }

            return new Response<IEnumerable<FloorDto>>(200, "Floors fetched successfully");
        }
    }
}
