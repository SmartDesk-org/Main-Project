using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom
{
    public class UpdateMeetingRoomDto
    {
        public string? RoomName { get; set; }
        public int? Capacity { get; set; }
        public float? XPosition { get; set; }
        public float? YPosition { get; set; }
        public string? SpecificationsJson { get; set; }
    }
}
