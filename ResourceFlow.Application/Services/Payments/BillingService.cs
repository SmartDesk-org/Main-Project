// using Microsoft.Extensions.Configuration;
// using ResourceFlow.Application.Common;
// using ResourceFlow.Application.Interfaces.Payments;
// using ResourceFlow.Application.Interfaces.Repositories;
// using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
// using ResourceFlow.Domain.Entities.Authentication;
// using ResourceFlow.Domain.Entities.Finance;
// using ResourceFlow.Domain.Entities.SubscriptionModels;
// using ResourceFlow.Domain.Enums;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace ResourceFlow.Application.Services.Payments
// {
//     public class BillingService:IBillingService
//     {
//         private readonly ICompanyDapperRepository _companyDapperRepo;
//         private readonly IGenericRepository<CompanySubscription> _companySubRepo;
//         private readonly IGenericRepository<Billing> _billRepo;
//         private readonly IConfiguration _config;
//         private readonly IGenericRepository<User> _userRepo;
//         public BillingService(
//             ICompanyDapperRepository companyDapperRepo,
//             IGenericRepository<CompanySubscription> companySubRepo,
//             IGenericRepository<Billing> billRepo,
//             IGenericRepository<User> userRepo,
//             IConfiguration config
//             )
//         {
//             _companyDapperRepo = companyDapperRepo;
//             _companySubRepo = companySubRepo;
//             _billRepo = billRepo;
//             _userRepo = userRepo;
//             _config = config;
//         }

//         public async Task<Billing> CreateBill(int companyId,string intentId)
//         {
//             var company =await  _companyDapperRepo.GetCompanyByCompanyId(companyId);

//             Console.WriteLine("_________________"); Console.WriteLine("from billing service ,company:"); Console.WriteLine(company.CompanySubscriptionId);
//             var compSub = await _companySubRepo.GetByIdAsync(company.CompanySubscriptionId);
//             Console.WriteLine("_________________"); Console.WriteLine("from billing service ,compSub:"); Console.WriteLine(compSub.Id);
//             var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name);
//             Console.WriteLine("_________________"); Console.WriteLine("from billing service ,user:"); Console.WriteLine(user.UserId);

//             var totalAmount = Convert.ToDecimal(compSub?.AmoutToBePaid);
//             var withoutTax = totalAmount-((totalAmount/100)*18);
//             var tax = totalAmount-withoutTax;

//             var bill = new Billing
//             {
//                 CompanyId = company.CompanyId,
//                 CompanyName = company.Name,
//                 CompanyMail=user.Email,
//                 SubscriptionId = compSub.SubscriptionId,
//                 SubscriptionName = compSub?.Subscription?.SubscriptionName,
//                 CompanySubscriptionId = company.CompanySubscriptionId,

//                 InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..6]}",

//                 SubTotal = withoutTax,
//                 TaxAmount = tax,
//                 Discount = 0,
//                 TotalAmount = withoutTax + tax,

//                 PaymentStatus = PaymentStatus.paid,
//                 PaymentMethod = PaymentMethod.Strip,

//                 TransactionId = intentId,

//                 BillingDate = DateTime.UtcNow,
//                 SubscriptionStartDate = compSub.StartDate,
//                 SubscriptionEndDate = compSub.EndDate,

//                 InvoicePdfPath = null,

//             };

//            var newBill= await _billRepo.AddAsync(bill);

//             return newBill;

//         }
//     }
// }



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
    public class BillingService : IBillingService
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

        public async Task<Billing> CreateBill(int companyId, string intentId)
        {
            // 1. Get Company
            var company = await _companyDapperRepo.GetCompanyByCompanyId(companyId);

//<<<<<<< HEAD
//            Console.WriteLine("_________________"); Console.WriteLine("from billing service ,company:"); Console.WriteLine(company.CompanySubscriptionId);
//            var compSub = await _companySubRepo.GetByIdAsync(company.CompanySubscriptionId);
//            Console.WriteLine("_________________"); Console.WriteLine("from billing service ,compSub:"); Console.WriteLine(compSub.Id);
//            var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name);
//            Console.WriteLine("_________________"); Console.WriteLine("from billing service ,user:"); Console.WriteLine(user.UserId);
//=======
            if (company == null)
            {
                Console.WriteLine($"[BillingService] Error: Company with ID {companyId} not found.");
                return null;
            }

            Console.WriteLine("_________________");
            Console.WriteLine("from billing service ,company:");
            Console.WriteLine(company.CompanySubscriptionId);

            // 2. Get Subscription
            var compSub = await _companySubRepo.GetByIdAsync(company.CompanySubscriptionId);


            // --- FIX IS HERE: Check if compSub is null ---
            if (compSub == null)
            {
                Console.WriteLine($"[BillingService] Error: CompanySubscription with ID {company.CompanySubscriptionId} not found.");
                return null; 
            }
            // ---------------------------------------------

            Console.WriteLine("_________________");
            Console.WriteLine("from billing service ,compSub:");
            Console.WriteLine(compSub.Id); // Now safe to access

            // 3. Get User
            var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name);

            // --- SAFETY CHECK FOR USER ---
            if (user == null)
            {
                Console.WriteLine($"[BillingService] Error: Admin user for company '{company.Name}' not found.");
                return null;
            }
            // -----------------------------

            Console.WriteLine("_________________");
            Console.WriteLine("from billing service ,user:");
            Console.WriteLine(user.UserId);

            // Calculations
            var totalAmount = Convert.ToDecimal(compSub.AmoutToBePaid); // removed ?. since we checked null above
            var withoutTax = totalAmount - ((totalAmount / 100) * 18);
            var tax = totalAmount - withoutTax;

            var bill = new Billing
            {
                CompanyId = company.CompanyId,
                CompanyName = company.Name,
                CompanyMail = user.Email,
                SubscriptionId = compSub.SubscriptionId,
                SubscriptionName = compSub.Subscription?.SubscriptionName ?? "Unknown Plan", // Handle null navigation property
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

            var newBill = await _billRepo.AddAsync(bill);

            return newBill;
        }
    }
}