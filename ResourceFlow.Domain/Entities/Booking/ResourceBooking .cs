using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Resource_Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Booking
{
    public class ResourceBooking:BaseEntity
    {
        public int Id { get; set; }

        // Multi-tenant
        public int CompanyId { get; set; }

        // What is booked (PHYSICAL instance)
        public int ResourceId { get; set; }

        // Helpful for permission & filtering
        public int ResourceTypeId { get; set; }

        // Who booked
        public int BookedByUserId { get; set; }

        // Time window
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Booking lifecycle
        public BookingStatus Status { get; set; }

        // Optional usage tracking
     

        // Navigation
        public Resource Resource { get; set; } = null!;
        public ResourceType ResourceType { get; set; } = null!;
        public CompanyDetails CompanyDetails { get; set; }
    }
}
