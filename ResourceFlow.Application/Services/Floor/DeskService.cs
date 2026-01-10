using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Company;
using System.Text.Json;

namespace ResourceFlow.Application.Services
{
    public class DeskService : IDeskService
    {
        private readonly IGenericRepository<CompanyDesk> _deskRepository;
        private readonly IGenericRepository<CompanyFloor> _floorRepository;
        private readonly IMapper _mapper;

        public DeskService(
            IGenericRepository<CompanyDesk> deskRepository,
            IGenericRepository<CompanyFloor> floorRepository,
            IMapper mapper)
        {
            _deskRepository = deskRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<DeskDto>> CreateDeskAsync(CreateDeskDto createDeskDto)
        {
            try
            {
                // Check if floor exists
                var floor = await _floorRepository.GetByIdAsync(createDeskDto.FloorId);
                if (floor == null || !floor.IsActive)
                    return ApiResponse<DeskDto>.Error("Floor not found", 404);

                // 🔒 SUBSCRIPTION CHECK (TEMP DISABLED)
                /*
                var canAdd = await _subscriptionService.CanAddDeskAsync(floor.CompanyId);
                if (!canAdd)
                {
                    return ApiResponse<DeskDto>.Error(
                        "Desk limit exceeded. Please upgrade your subscription.",
                        403);
                }
                */

                var desk = _mapper.Map<CompanyDesk>(createDeskDto);
                desk.Status = Domain.Enums.Company.ResourceStatus.Available;

                var createdDesk = await _deskRepository.AddAsync(desk);
                var deskDto = _mapper.Map<DeskDto>(createdDesk);

                return ApiResponse<DeskDto>.Created(deskDto, "Desk created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<DeskDto>.Error($"Failed to create desk: {ex.Message}");
            }
        }


        public async Task<ApiResponse<DeskDto>> GetDeskByIdAsync(int id)
        {
            try
            {
                var desk = await _deskRepository.GetQueryable()
                    .Include(d => d.Floor)
                    .FirstOrDefaultAsync(d => d.DeskId == id);

                if (desk == null)
                    return ApiResponse<DeskDto>.Error("Desk not found", 404);

                var deskDto = _mapper.Map<DeskDto>(desk);
                return ApiResponse<DeskDto>.Success(deskDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<DeskDto>.Error($"Failed to get desk: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<DeskDto>>> GetDesksByFloorAsync(int floorId)
        {
            try
            {
                var desks = await _deskRepository.GetQueryable()
                    .Include(d => d.Floor)
                    .Where(d => d.FloorId == floorId)
                    .ToListAsync();

                var deskDtos = _mapper.Map<List<DeskDto>>(desks);
                return ApiResponse<List<DeskDto>>.Success(deskDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<DeskDto>>.Error($"Failed to get desks: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DeskDto>> UpdateDeskAsync(int id, UpdateDeskDto updateDeskDto)
        {
            try
            {
                var desk = await _deskRepository.GetByIdAsync(id);
                if (desk == null)
                    return ApiResponse<DeskDto>.Error("Desk not found", 404);

                _mapper.Map(updateDeskDto, desk);

                // Handle specifications JSON update
                if (updateDeskDto.SpecificationsJson.HasValue)
                {
                    desk.SpecificationsJson = updateDeskDto.SpecificationsJson.Value.ToString();
                }

                await _deskRepository.UpdateAsync(desk);

                var updatedDesk = await _deskRepository.GetQueryable()
                    .Include(d => d.Floor)
                    .FirstOrDefaultAsync(d => d.DeskId == id);

                var deskDto = _mapper.Map<DeskDto>(updatedDesk);
                return ApiResponse<DeskDto>.Success(deskDto, "Desk updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<DeskDto>.Error($"Failed to update desk: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DeskDto>> UpdateDeskStatusAsync(int id, UpdateDeskStatusDto statusDto)
        {
            try
            {
                var desk = await _deskRepository.GetByIdAsync(id);
                if (desk == null)
                    return ApiResponse<DeskDto>.Error("Desk not found", 404);

                desk.Status = statusDto.Status;
                await _deskRepository.UpdateAsync(desk);

                var updatedDesk = await _deskRepository.GetQueryable()
                    .Include(d => d.Floor)
                    .FirstOrDefaultAsync(d => d.DeskId == id);

                var deskDto = _mapper.Map<DeskDto>(updatedDesk);
                return ApiResponse<DeskDto>.Success(deskDto, "Desk status updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<DeskDto>.Error($"Failed to update desk status: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteDeskAsync(int id)
        {
            var desk = await _deskRepository.SingleOrDefaultAsync(d => d.DeskId == id);
            if (desk == null)
            {
                return new ApiResponse<bool>
                {
                    StatusCode = 404,
                    Message = "Desk not found",
                    Data = false
                };
            }

            // Soft delete approach: set status to inactive
            desk.Status = ResourceStatus.Deleted; // or add IsActive = false property if you have
            await _deskRepository.UpdateAsync(desk);

            return new ApiResponse<bool>
            {
                StatusCode = 200,
                Message = "Desk deleted successfully",
                Data = true
            };
        }

    }
}