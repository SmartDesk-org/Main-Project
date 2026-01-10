using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Floor
{
    public class CreateFloorDto
    {
        public string FloorName { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
        public string Map { get; set; } = string.Empty;
        public int CompanyId { get; set; }
    }
}
