using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Floor
{
    public class FloorDto
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
        public int CompanyId { get; set; }
        public string Map { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public List<DeskDto> Desks { get; set; } = new();
        public List<MeetingRoomDto> MeetingRooms { get; set; } = new();
    }
}
