using ResourceFlow.Domain.Enums.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class CompanyMeetingRoom : BaseEntity
    {
        public int RoomId { get; set; }
        public int CompanyId { get; set; }
        public int FloorId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public ResourceStatus Status { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public string SpecificationsJson { get; set; } = string.Empty;

        // Navigation properties
        public virtual CompanyDetails Company { get; set; } = null!;
        public virtual CompanyFloor Floor { get; set; } = null!;
    }
}
