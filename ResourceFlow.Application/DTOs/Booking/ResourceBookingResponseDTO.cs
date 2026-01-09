using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Booking
{
    public class ResourceBookingResponseDTO
    {
        public int BookingId { get; set; }
        public int CompanyId { get; set; }         // Company owning the booking
        public int ResourceId { get; set; }        // Resource booked
        public int ResourceTypeId { get; set; }    // Type of resource
        public int BookedByUserId { get; set; }    // User who booked
        public DateTime StartTime { get; set; }    // Booking start
        public DateTime EndTime { get; set; }      // Booking end
        public string Status { get; set; }
    }
}
