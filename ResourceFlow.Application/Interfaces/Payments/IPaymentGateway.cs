using ResourceFlow.Application.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Payments
{
    public  interface IPaymentGateway
    {
        Task<CreatePaymentIntentResponseDto> CreatePaymentIntentAsync(int companyId, int amountInRupees);
        Task<bool> VerifyPaymentAsync(string paymentIntentId);
    }
}
