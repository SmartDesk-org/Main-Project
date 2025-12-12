using ResourceFlow.Application.DTOs.Payments;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Payments
{
    public class PaymentService
    {
        private readonly IPaymentGateway _gateway;
        private readonly IGenericRepository<Payment> _paymentRepo;

        public PaymentService(IPaymentGateway gateway, IGenericRepository<Payment> paymentRepo)
        {
            _gateway = gateway;
            _paymentRepo = paymentRepo;
        }

        public Task<CreatePaymentIntentResponseDto> CreatePaymentIntent(int companyId, int amount)
        {
            return _gateway.CreatePaymentIntentAsync(companyId, amount);
        }

        public async Task<bool> ConfirmPaymentAsync(string paymentIntentId, int companyId)
        {
            Console.WriteLine($"payment service reached with {paymentIntentId} and {companyId}");
            var isPaid = await _gateway.VerifyPaymentAsync(paymentIntentId);
            Console.WriteLine($"is paid : {isPaid}");
            if (!isPaid)
                return false;

            var record = await _paymentRepo.SingleOrDefaultAsync(x => x.PaymentIntentId == paymentIntentId);

            if (record != null)
            {
                record.PaymentStatus = PaymentStatus.paid;
                await _paymentRepo.UpdateAsync(record);
            }

            return true;
        }
    }

}
