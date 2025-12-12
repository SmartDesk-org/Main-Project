using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Payments
{
    public class CreatePaymentIntentResponseDto
    {
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
    }

  
}
