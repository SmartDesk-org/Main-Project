using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Enums.Company
{
    public enum ResourceStatus
    {
        Available,
        Occupied,
        Maintenance,
        Reserved,
        Unavailable,
        Deleted
    }
}
