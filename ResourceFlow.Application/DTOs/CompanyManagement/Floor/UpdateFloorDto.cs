using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Floor
{
    public class UpdateFloorDto
    {
        public string? FloorName { get; set; }
        public int? FloorNumber { get; set; }
        public string? Map { get; set; }
        public bool? IsActive { get; set; }
    }
}
