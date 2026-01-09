using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Enums.Resource_Booking
{
    public enum BookingStatus
    {

        Pending = 1,
        Confirmed = 2,
        CheckedIn = 3,
        Expired = 4,
        Cancelled = 5,
        Rejected = 6

    }
}
