using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public  class CompanyFloor:BaseEntity
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; } = default!;
        public int FloorNumber { get; set; }
        public int CompanyId { get; set; }
        public string Map { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public CompanyDetails Company { get; set; } = null!;
        public ICollection<CompanyDesk> Desks { get; set; } = new List<CompanyDesk>();
        public ICollection<CompanyMeetingRoom> MeetingRooms { get; set; } = new List<CompanyMeetingRoom>();


    }
}
