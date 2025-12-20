using ResourceFlow.Domain.Enums.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class CompanyDesk:BaseEntity
    {
        public int DeskId { get; set; }
        public int CompanyId { get; set; }
        public int FloorId { get; set; }

        public string Name { get; set; } = null!;
        public ResourceStatus Status { get; set; }

        public float XPosition { get; set; }
        public float YPosition { get; set; }

        public string SpecificationsJson { get; set; } = string.Empty;
        public CompanyDetails Company { get; set; } = null!;
        public CompanyFloor Floor { get; set; } = null!;
    }
}
