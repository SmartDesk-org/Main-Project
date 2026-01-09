using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Booking
{
    public class CompanyResourceBookingPermission:BaseEntity
    {
        public int Id { get; set; } 
        public int CompanyId { get; set; }
        public int ResourceTypeId { get; set; }  // MeetingRoom
        public ResourceType ResourceType { get; set; }

        public string EmployeeType { get; set; } // Manager, Lead, 
        public bool CanBook { get; set; } = true;  // 

    }
}