using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Floor
{
    public class FloorLayoutDto
    {
        public JsonElement LayoutJson { get; set; }
        public List<DeskPositionDto> Desks { get; set; } = new();
        public List<MeetingRoomPositionDto> MeetingRooms { get; set; } = new();
    }
}
