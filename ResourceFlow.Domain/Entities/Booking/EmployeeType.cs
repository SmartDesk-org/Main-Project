using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Booking
{
    public class EmployeeType:BaseEntity
    {
        public int EmployeeTypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public ICollection<CompanyResourceBookingPermission> BookingPermissions { get; set; } = new List<CompanyResourceBookingPermission>();

    }
}
