using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Enums
{
    public enum HistoryChangeReasonEnum
    {
        Initial_Purchase=1,
        Upgrade=2,
        Downgrade=3,
        Renewal=4, 
        Expired=5,
        Cancelled=6
        
    }
}
