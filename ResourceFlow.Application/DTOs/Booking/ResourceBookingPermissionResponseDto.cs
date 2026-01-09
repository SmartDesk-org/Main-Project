using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Booking
{
    public class ResourceBookingPermissionResponseDto
    {
        public int CompanyId { get; set; }
        public int ResourceTypeId { get; set; }

        public List<string> AllowedEmployeeTypes { get; set; } = new();
    }
}
