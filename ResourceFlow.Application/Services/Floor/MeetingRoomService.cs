using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Company;
using System.Text.Json;

namespace ResourceFlow.Application.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IGenericRepository<CompanyMeetingRoom> _meetingRoomRepository;
        private readonly IGenericRepository<CompanyFloor> _floorRepository;
        private readonly IMapper _mapper;

        public MeetingRoomService(
            IGenericRepository<CompanyMeetingRoom> meetingRoomRepository,
            IGenericRepository<CompanyFloor> floorRepository,
            IMapper mapper)
        {
            _meetingRoomRepository = meetingRoomRepository;
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<MeetingRoomDto>> CreateMeetingRoomAsync(CreateMeetingRoomDto createMeetingRoomDto)
        {
            try
            {
                // Check if floor exists
                var floor = await _floorRepository.GetByIdAsync(createMeetingRoomDto.FloorId);
                if (floor == null || !floor.IsActive)
                    return ApiResponse<MeetingRoomDto>.Error("Floor not found", 404);

                // 🔒 SUBSCRIPTION CHECK (TEMP DISABLED)
                // TODO: Enable once SubscriptionService is integrated
                /*
                var canAdd = await _subscriptionService.CanAddMeetingRoomAsync(floor.CompanyId);
                if (!canAdd)
                {
                    return ApiResponse<MeetingRoomDto>.Error(
                        "Meeting room limit exceeded. Please upgrade your subscription.",
                        403);
                }
                */

                var meetingRoom = _mapper.Map<CompanyMeetingRoom>(createMeetingRoomDto);
                meetingRoom.Status = Domain.Enums.Company.ResourceStatus.Available;

                var createdRoom = await _meetingRoomRepository.AddAsync(meetingRoom);
                var roomDto = _mapper.Map<MeetingRoomDto>(createdRoom);

                return ApiResponse<MeetingRoomDto>.Created(roomDto, "Meeting room created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<MeetingRoomDto>.Error($"Failed to create meeting room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<MeetingRoomDto>> GetMeetingRoomByIdAsync(int id)
        {
            try
            {
                var meetingRoom = await _meetingRoomRepository.GetQueryable()
                    .Include(m => m.Floor)
                    .FirstOrDefaultAsync(m => m.RoomId == id);

                if (meetingRoom == null)
                    return ApiResponse<MeetingRoomDto>.Error("Meeting room not found", 404);

                var roomDto = _mapper.Map<MeetingRoomDto>(meetingRoom);
                return ApiResponse<MeetingRoomDto>.Success(roomDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<MeetingRoomDto>.Error($"Failed to get meeting room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<MeetingRoomDto>>> GetMeetingRoomsByFloorAsync(int floorId)
        {
            try
            {
                var meetingRooms = await _meetingRoomRepository.GetQueryable()
                    .Include(m => m.Floor)
                    .Where(m => m.FloorId == floorId)
                    .ToListAsync();

                var roomDtos = _mapper.Map<List<MeetingRoomDto>>(meetingRooms);
                return ApiResponse<List<MeetingRoomDto>>.Success(roomDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<MeetingRoomDto>>.Error($"Failed to get meeting rooms: {ex.Message}");
            }
        }

        public async Task<ApiResponse<MeetingRoomDto>> UpdateMeetingRoomAsync(int id, UpdateMeetingRoomDto updateMeetingRoomDto)
        {
            try
            {
                var meetingRoom = await _meetingRoomRepository.GetByIdAsync(id);
                if (meetingRoom == null)
                    return ApiResponse<MeetingRoomDto>.Error("Meeting room not found", 404);

                // Map only non-null properties from DTO to entity
                _mapper.Map(updateMeetingRoomDto, meetingRoom);

                // No need for manual string conversion — AutoMapper already handled it
                await _meetingRoomRepository.UpdateAsync(meetingRoom);

                var updatedRoom = await _meetingRoomRepository.GetQueryable()
                    .Include(m => m.Floor)
                    .FirstOrDefaultAsync(m => m.RoomId == id);

                var roomDto = _mapper.Map<MeetingRoomDto>(updatedRoom);
                return ApiResponse<MeetingRoomDto>.Success(roomDto, "Meeting room updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<MeetingRoomDto>.Error($"Failed to update meeting room: {ex.Message}");
            }
        }


        public async Task<ApiResponse<bool>> DeleteMeetingRoomAsync(int id, int userId)
        {
            var room = await _meetingRoomRepository.SingleOrDefaultAsync(r => r.RoomId == id);
            if (room == null)
            {
                return new ApiResponse<bool>
                {
                    StatusCode = 404,
                    Message = "Meeting room not found",
                    Data = false
                };
            }

            // Soft delete proper
            room.IsDelete = true;               // 🔹 mark as deleted
            room.DeletedAt = DateTime.UtcNow;   // 🔹 set deleted timestamp
            room.DeletedBy = userId;            // 🔹 set user who deleted
            room.Status = ResourceStatus.Deleted;

            await _meetingRoomRepository.UpdateAsync(room);

            return new ApiResponse<bool>
            {
                StatusCode = 200,
                Message = "Meeting room deleted successfully",
                Data = true
            };
        }


    }


}