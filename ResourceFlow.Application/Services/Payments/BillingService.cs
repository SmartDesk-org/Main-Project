using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Payments
{
    public class BillingService:IBillingService
    {
        private readonly ICompanyDapperRepository _companyDapperRepo;
        private readonly IGenericRepository<CompanySubscription> _companySubRepo;
        private readonly IGenericRepository<Billing> _billRepo;
        private readonly IConfiguration _config;
        private readonly IGenericRepository<User> _userRepo;
        public BillingService(
            ICompanyDapperRepository companyDapperRepo,
            IGenericRepository<CompanySubscription> companySubRepo,
            IGenericRepository<Billing> billRepo,
            IGenericRepository<User> userRepo,
            IConfiguration config
            )
        {
            _companyDapperRepo = companyDapperRepo;
            _companySubRepo = companySubRepo;
            _billRepo = billRepo;
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<Billing> CreateBill(int companyId,string intentId)
        {
            var company =await  _companyDapperRepo.GetCompanyByCompanyId(companyId);

            Console.WriteLine("from billing company {0}, {1}", company.CompanyId, company.CompanySubscriptionId);
            var compSub = await _companySubRepo.GetByIdAsync(company.CompanySubscriptionId);
            var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name);
            Console.WriteLine("_________________"); Console.WriteLine("from billing service ,user:"); Console.WriteLine(user);

            var totalAmount = Convert.ToDecimal(compSub?.AmoutToBePaid);
            var withoutTax = totalAmount-((totalAmount/100)*18);
            var tax = totalAmount-withoutTax;

            var bill = new Billing
            {
                CompanyId = company.CompanyId,
                CompanyName = company.Name,
                CompanyMail=user.Email,
                SubscriptionId = compSub.SubscriptionId,
                SubscriptionName = compSub?.Subscription?.SubscriptionName,
                CompanySubscriptionId = company.CompanySubscriptionId,

                InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..6]}",

                SubTotal = withoutTax,
                TaxAmount = tax,
                Discount = 0,
                TotalAmount = withoutTax + tax,

                PaymentStatus = PaymentStatus.paid,
                PaymentMethod = PaymentMethod.Strip,

                TransactionId = intentId,

                BillingDate = DateTime.UtcNow,
                SubscriptionStartDate = compSub.StartDate,
                SubscriptionEndDate = compSub.EndDate,

                InvoicePdfPath = null,

            };

           var newBill= await _billRepo.AddAsync(bill);

            return newBill;

        }
    }
}
