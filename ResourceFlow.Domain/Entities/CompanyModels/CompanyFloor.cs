using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class CompanyFloor : BaseEntity
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
        public int CompanyId { get; set; }
        public string Map { get; set; } = string.Empty; //floor ly des store
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual CompanyDetails Company { get; set; } = null!;
        public virtual ICollection<CompanyDesk> Desks { get; set; } = new List<CompanyDesk>();
        public virtual ICollection<CompanyMeetingRoom> MeetingRooms { get; set; } = new List<CompanyMeetingRoom>();
    }
}
