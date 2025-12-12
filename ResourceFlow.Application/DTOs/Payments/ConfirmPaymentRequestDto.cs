using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Payments
{
    public class ConfirmPaymentRequestDto
    {
        public string PaymentIntentId { get; set; }
        public int CompanyId { get; set; }
    }
}
