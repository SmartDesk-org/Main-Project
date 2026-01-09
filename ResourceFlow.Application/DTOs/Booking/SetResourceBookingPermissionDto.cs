using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Booking
{
    public class SetResourceBookingPermissionDto
    {

        public int ResourceTypeId { get; set; }
        public string EmployeeTypes { get; set; }
        public bool CanBook { get; set; }
    }
}
