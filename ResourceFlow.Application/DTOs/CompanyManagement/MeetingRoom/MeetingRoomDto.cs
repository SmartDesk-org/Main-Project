using ResourceFlow.Domain.Enums.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom
{
    public class MeetingRoomDto
    {
        public int RoomId { get; set; }
        public int CompanyId { get; set; }
        public int FloorId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public ResourceStatus Status { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public JsonElement SpecificationsJson { get; set; }
    }
}
