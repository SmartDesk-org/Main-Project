using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Booking
{
    public class ScanQRCodeRequest
    {
        public string QrValue { get; set; } = null!;
    }
}
