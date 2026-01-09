using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Payments;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;



namespace ResourceFlow.Application.Services.Payments
{
    public class PaymentService
    {
        private readonly IPaymentGateway _gateway;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<CompanySubscription> _compSubRepo;
        private readonly IBillingService _billingService;
        private readonly IPdfService _pdfService;
        private readonly IEmailService _emailService;

        public PaymentService(IPaymentGateway gateway, IGenericRepository<Payment> paymentRepo,IGenericRepository<CompanySubscription> compSubRepo, IBillingService billingService,IPdfService pdfService,IEmailService emailService)
        {
            _gateway = gateway;
            _paymentRepo = paymentRepo;
            _compSubRepo = compSubRepo;
            _billingService= billingService;
            _pdfService = pdfService;
            _emailService = emailService;

        }

        public async Task<CreatePaymentIntentResponseDto> CreatePaymentIntent(int companyId)
        {
            var sub=await _compSubRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.IsDeleted == false && x.IsActive == false);

            return await _gateway.CreatePaymentIntentAsync(companyId,sub.AmoutToBePaid);
        }

        public async Task<Response<Billing>> ConfirmPaymentAsync(string paymentIntentId, int companyId)
        {
            Console.WriteLine($"payment service reached with {paymentIntentId} and {companyId}");

            var isPaid = await _gateway.VerifyPaymentAsync(paymentIntentId);

            Console.WriteLine($"is paid : {isPaid}");
            if (!isPaid)
                return new Response<Billing>(400,"Payment failed");

            var record = await _paymentRepo.SingleOrDefaultAsync(x => x.PaymentIntentId == paymentIntentId);

            if (record != null)
            {
                record.PaymentStatus = PaymentStatus.paid;
                await _paymentRepo.UpdateAsync(record);
            }

            var bill =await  _billingService.CreateBill(companyId,paymentIntentId);
            if (bill == null)
                return new Response<Billing>(400, "Payment failed");

            var pdf =  _pdfService.GeneratePdf(bill);
            Console.WriteLine("_________________"); Console.WriteLine("from payment service ,pdf:"); Console.WriteLine(pdf);
            await _emailService.SendBillAsync(bill.CompanyMail,pdf);


            return new Response<Billing>(200,"Payment Confirmed",bill);
        }
    }

}
