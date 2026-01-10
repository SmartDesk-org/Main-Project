using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IMeetingRoomService
    {
        Task<ApiResponse<MeetingRoomDto>> CreateMeetingRoomAsync(CreateMeetingRoomDto createMeetingRoomDto);
        Task<ApiResponse<MeetingRoomDto>> GetMeetingRoomByIdAsync(int id);
        Task<ApiResponse<List<MeetingRoomDto>>> GetMeetingRoomsByFloorAsync(int floorId);
        Task<ApiResponse<MeetingRoomDto>> UpdateMeetingRoomAsync(int id, UpdateMeetingRoomDto updateMeetingRoomDto);

        Task<ApiResponse<bool>> DeleteMeetingRoomAsync(int id, int userId);

    }
}
