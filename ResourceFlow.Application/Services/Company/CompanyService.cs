using AutoMapper;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Company
{
    public class CompanyService:ICompanyService
    {
        private readonly IGenericRepository<CompanyDetails> _companyRepo;
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<CompanySubscription> _compSubRepo;
        private readonly IGenericRepository<Subscription> _subRepo;
        private readonly IGenericRepository<Resource> _resourceRepo;
        private readonly IGenericRepository<CompanyFloor> _floorRepo;
        private readonly IJwtService _jwtservice;
        private readonly IMapper _mapper;

        public CompanyService(
            IGenericRepository<CompanyDetails> companyRepo,
            IGenericRepository<User> userRepo,
            IGenericRepository<CompanySubscription> compSubRepo,
            IGenericRepository<Subscription> subRepo,
            IGenericRepository<Resource> resourceRepo,
            IGenericRepository<CompanyFloor> floorRepo,
            IMapper mapper
            )
        {
            _companyRepo = companyRepo;
            _userRepo = userRepo;
            _compSubRepo = compSubRepo;
            _subRepo = subRepo;
            _resourceRepo = resourceRepo;
            _floorRepo = floorRepo;
            _mapper = mapper;
        }


        public async Task<Response<IEnumerable<CompanyDetails>>> GetAllAsync()
        {
            var res =await  _companyRepo.GetAllAsync();
            if (res == null || !res.Any())
                return new Response<IEnumerable<CompanyDetails>>(404, "no client companies", res);
            return new Response<IEnumerable<CompanyDetails>>(200, "companies found", res);
        }
        public async Task<Response<Object>> NewCompany(NewCompanyDto dto)
        {
            var existing = await _companyRepo.SingleOrDefaultAsync(x => x.Name == dto.Name && x.IsDeleted == false);
            if (existing != null)
                return new Response<Object>( 404, "There is already a company with same name ");

            var company = new CompanyDetails
            {
                Name = dto.Name,
                Address=dto.Address,
                IsActive=false
            };
            var newCompany =await  _companyRepo.AddAsync(company);

            var user = new User
            {
                CompanyId=newCompany.CompanyId,
                UserName = newCompany.Name,
                Email = dto.Email.Trim(),
                PassWord = BCrypt.Net.BCrypt.HashPassword(dto.PassWord),
                RoleId = 2,
                IsActive = false,
                IsBlocked = false
            };
            var newUser = await _userRepo.AddAsync(user);

            var companySubscription = new CompanySubscription
            {
                CompanyId = newCompany.CompanyId,
                SubscriptionId = dto.SelectedSubscriptionId,
                StartDate = newCompany.CreatedAt,
                EndDate = newCompany.CreatedAt.AddYears(dto.ExpirationYear).AddMonths(dto.ExpirationMonth),
                IsActive = false,
                Status=SubscriptionStatus.Pending
            };
           

            var subPlan =await  _subRepo.GetByIdAsync(dto.SelectedSubscriptionId);

            var newCompanySubscription = await _compSubRepo.AddAsync(companySubscription);

            var start = newCompanySubscription.StartDate;
            var end = newCompanySubscription.EndDate;

            int years = end.Year - start.Year;
            if(end.Month<start.Month || (end.Month==start.Month && end.Day<start.Day))
            {
                years--;
            }

            start = start.AddYears(years);
            int months = end.Month - start.Month;
            if(end.Day<start.Day)
            {
                months--;
            }

            start = start.AddMonths(months);

            int days = (end - start).Days;

            double totalAmount = (years * subPlan.PriceYearly)
                                + (months * subPlan.PriceMonthly)
                                + (days * (subPlan.PriceMonthly / 30));

            newCompanySubscription.AmoutToBePaid = totalAmount;

            await _compSubRepo.UpdateAsync(newCompanySubscription);

           

            var res = new
            {
                CompanyId = newCompany.CompanyId,
                SubscritionName = subPlan.SubscriptionName,
                StartDate = newCompanySubscription.StartDate,
                EndDate = newCompanySubscription.EndDate,
                AmountToBEPaid = totalAmount,
                Currency="INR"
            };

            return new Response<Object>(200, "Company added successfully ,Proceed to payment", res);
        }


        public async Task ActivateCompanyAsync(int companyId)
        {
            var company = await _companyRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.IsDeleted == false);
            var subscription = await _compSubRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.IsDeleted == false);
            var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name && x.CompanyId == company.CompanyId && x.IsDeleted == false);

            if (user == null)
                throw new Exception("User not found for company");

            company.IsActive = true;
            subscription.IsActive = true;
            user.IsActive = true;

            var floor = new CompanyFloor

            {
                FloorName = "Default Floor",
                CompanyId = company.CompanyId,
                FloorNumber = 1,
                Map="just test"
            };

            await _floorRepo.AddAsync(floor);
            await _companyRepo.UpdateAsync(company);
            await _compSubRepo.UpdateAsync(subscription);
            await _userRepo.UpdateAsync(user);



        }
    }
}
