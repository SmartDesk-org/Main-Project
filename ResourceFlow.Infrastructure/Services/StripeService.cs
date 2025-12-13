using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ResourceFlow.Application.DTOs.Payments;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Services
{
    public  class StripeService:IPaymentGateway
    {
        private readonly string _secretKey;
        private readonly IGenericRepository<Payment> _paymentRepo;

        public StripeService(IConfiguration config, IGenericRepository<Payment> paymentRepo)
        {
            _secretKey = config["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;

            _paymentRepo = paymentRepo;
        }

        public async Task<CreatePaymentIntentResponseDto> CreatePaymentIntentAsync(int companyId, double amountInRupees)
        {
            var amountInPaise = Convert.ToInt64(Math.Ceiling(amountInRupees * 100));

            var receiptId = $"COMP-{companyId}-{DateTime.UtcNow.Ticks}";

            var options = new PaymentIntentCreateOptions
            {
                Amount = amountInPaise,
                Currency = "inr",
                Metadata = new Dictionary<string, string>
                 {
                     { "companyId", companyId.ToString() },
                     { "receiptId", receiptId }
                  },
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true
                }
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);

            var record = new Domain.Entities.Finance.Payment
            {
                CompanyId = companyId,
                PaymentIntentId = intent.Id,
                ReceiptId = receiptId,
                Amount = amountInRupees,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Pending
            };

            await _paymentRepo.AddAsync(record);

            return new CreatePaymentIntentResponseDto
            {
                ClientSecret = intent.ClientSecret,
                PaymentIntentId = intent.Id,
                Amount = amountInPaise,
                Currency = "INR"
            };
        }

        public async Task<bool> VerifyPaymentAsync(string paymentIntentId)
        {
            Console.WriteLine($"from gateway {paymentIntentId}");
            var service = new PaymentIntentService();
            var intent = await service.GetAsync(paymentIntentId);
            Console.WriteLine($"intent {intent.Status}");
            return intent.Status == "succeeded";
        }
    }
}
