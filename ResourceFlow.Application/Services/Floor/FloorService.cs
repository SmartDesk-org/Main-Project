using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Floor;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.CompanyModels;
using System.Text.Json;

namespace ResourceFlow.Application.Services
{
    public class FloorService : IFloorService
    {
        private readonly IGenericRepository<CompanyFloor> _floorRepository;
        private readonly IGenericRepository<CompanyDesk> _deskRepository;
        private readonly IGenericRepository<CompanyMeetingRoom> _meetingRoomRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public FloorService(
            IGenericRepository<CompanyFloor> floorRepository,
            IGenericRepository<CompanyDesk> deskRepository,
            IGenericRepository<CompanyMeetingRoom> meetingRoomRepository,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _floorRepository = floorRepository;
            _deskRepository = deskRepository;
            _meetingRoomRepository = meetingRoomRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ApiResponse<FloorDto>> CreateFloorAsync(CreateFloorDto createFloorDto)
        {
            try
            {
                // 🔒 SUBSCRIPTION CHECK (TEMP DISABLED)
                // TODO: Enable once SubscriptionService is integrated
                /*
                var canAdd = await _subscriptionService.CanAddFloorAsync(createFloorDto.CompanyId);
                if (!canAdd)
                {
                    return ApiResponse<FloorDto>.Error(
                        "Floor limit exceeded. Please upgrade your subscription.",
                        403);
                }
                */

                var floor = _mapper.Map<CompanyFloor>(createFloorDto);
                floor.IsActive = true;

                var createdFloor = await _floorRepository.AddAsync(floor);
                var floorDto = _mapper.Map<FloorDto>(createdFloor);

                return ApiResponse<FloorDto>.Created(floorDto, "Floor created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<FloorDto>.Error($"Failed to create floor: {ex.Message}");
            }
        }


        public async Task<ApiResponse<FloorDto>> GetFloorByIdAsync(int id)
        {
            try
            {
                var floor = await _floorRepository.GetQueryable()
                    .Include(f => f.Desks)
                    .Include(f => f.MeetingRooms)
                    .FirstOrDefaultAsync(f => f.FloorId == id && f.IsActive);

                if (floor == null)
                    return ApiResponse<FloorDto>.Error("Floor not found", 404);

                var floorDto = _mapper.Map<FloorDto>(floor);
                return ApiResponse<FloorDto>.Success(floorDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<FloorDto>.Error($"Failed to get floor: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<FloorDto>>> GetAllFloorsAsync(int companyId)
        {
            try
            {
                var floors = await _floorRepository.GetQueryable()
                    .Include(f => f.Desks)
                    .Include(f => f.MeetingRooms)
                    .Where(f => f.CompanyId == companyId && f.IsActive)
                    .ToListAsync();

                var floorDtos = _mapper.Map<List<FloorDto>>(floors);
                return ApiResponse<List<FloorDto>>.Success(floorDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<FloorDto>>.Error($"Failed to get floors: {ex.Message}");
            }
        }

        public async Task<ApiResponse<FloorDto>> UpdateFloorAsync(int id, UpdateFloorDto updateFloorDto)
        {
            try
            {
                var floor = await _floorRepository.GetByIdAsync(id);
                if (floor == null || !floor.IsActive)
                    return ApiResponse<FloorDto>.Error("Floor not found", 404);

                _mapper.Map(updateFloorDto, floor);
                await _floorRepository.UpdateAsync(floor);

                var updatedFloor = await _floorRepository.GetQueryable()
                    .Include(f => f.Desks)
                    .Include(f => f.MeetingRooms)
                    .FirstOrDefaultAsync(f => f.FloorId == id);

                var floorDto = _mapper.Map<FloorDto>(updatedFloor);
                return ApiResponse<FloorDto>.Success(floorDto, "Floor updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<FloorDto>.Error($"Failed to update floor: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteFloorAsync(int id)
        {
            try
            {
                var floor = await _floorRepository.GetByIdAsync(id);
                if (floor == null)
                    return ApiResponse<bool>.Error("Floor not found", 404);

                floor.IsActive = false;
                await _floorRepository.UpdateAsync(floor);

                return ApiResponse<bool>.Success(true, "Floor deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Error($"Failed to delete floor: {ex.Message}");
            }
        }

        // FloorService.cs - UpdateFloorLayoutAsync method തിരുത്തുക
        public async Task<ApiResponse<FloorDto>> UpdateFloorLayoutAsync(int id, FloorLayoutDto layoutDto)
        {
            try
            {
                var floor = await _floorRepository.GetByIdAsync(id);
                if (floor == null || !floor.IsActive)
                    return ApiResponse<FloorDto>.Error("Floor not found", 404);

                // Validate JSON
                if (!IsValidJson(layoutDto.LayoutJson.ToString()))
                    return ApiResponse<FloorDto>.Error("Invalid layout JSON format", 400);

                floor.Map = layoutDto.LayoutJson.ToString();

                // Update desks
                foreach (var deskPos in layoutDto.Desks)
                {
                    // 🔥 companyId check ചെയ്യേണ്ടതില്ല, ഞങ്ങൾ ഇപ്പോൾ ഉള്ള validation മതി
                    var desk = await _deskRepository.GetByIdAsync(deskPos.DeskId);
                    if (desk != null && desk.FloorId == id) // companyId check removed
                    {
                        desk.XPosition = deskPos.XPosition;
                        desk.YPosition = deskPos.YPosition;
                        await _deskRepository.UpdateAsync(desk);
                    }
                }

                // Update meeting rooms
                foreach (var roomPos in layoutDto.MeetingRooms)
                {
                    var room = await _meetingRoomRepository.GetByIdAsync(roomPos.RoomId);
                    if (room != null && room.FloorId == id) // companyId check removed
                    {
                        room.XPosition = roomPos.XPosition;
                        room.YPosition = roomPos.YPosition;
                        await _meetingRoomRepository.UpdateAsync(room);
                    }
                }

                await _floorRepository.UpdateAsync(floor);

                var updatedFloor = await _floorRepository.GetQueryable()
                    .Include(f => f.Desks)
                    .Include(f => f.MeetingRooms)
                    .FirstOrDefaultAsync(f => f.FloorId == id);

                var floorDto = _mapper.Map<FloorDto>(updatedFloor);
                return ApiResponse<FloorDto>.Success(floorDto, "Floor layout updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<FloorDto>.Error($"Failed to update floor layout: {ex.Message}");
            }
        }
        private bool IsValidJson(string jsonString)
        {
            try
            {
                JsonDocument.Parse(jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}