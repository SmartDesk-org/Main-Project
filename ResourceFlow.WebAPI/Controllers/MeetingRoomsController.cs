using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;
using ResourceFlow.Application.Interfaces.Services;

namespace ResourceFlow.WebAPI.Controllers.CompanyManagement
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomsController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetingRoom([FromBody] CreateMeetingRoomDto createMeetingRoomDto)
        {
            var result = await _meetingRoomService.CreateMeetingRoomAsync(createMeetingRoomDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingRoom(int id)
        {
            var result = await _meetingRoomService.GetMeetingRoomByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("floor/{floorId}")]
        public async Task<IActionResult> GetMeetingRoomsByFloor(int floorId)
        {
            var result = await _meetingRoomService.GetMeetingRoomsByFloorAsync(floorId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeetingRoom(int id, [FromBody] UpdateMeetingRoomDto updateMeetingRoomDto)
        {
            var result = await _meetingRoomService.UpdateMeetingRoomAsync(id, updateMeetingRoomDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(int id)
        {
            int userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0"); // or get from claims

            var result = await _meetingRoomService.DeleteMeetingRoomAsync(id, userId);
            return StatusCode(result.StatusCode, result);
        }


    }
}