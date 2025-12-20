using AutoMapper;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
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
        private readonly IGenericRepository<SubscriptionHistory> _historyRepo;
        private readonly IJwtService _jwtservice;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(
            IGenericRepository<CompanyDetails> companyRepo,
            IGenericRepository<User> userRepo,
            IGenericRepository<CompanySubscription> compSubRepo,
            IGenericRepository<Subscription> subRepo,
            IGenericRepository<Resource> resourceRepo,
            IGenericRepository<CompanyFloor> floorRepo,
            IGenericRepository<SubscriptionHistory> historyRepo,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _companyRepo = companyRepo;
            _userRepo = userRepo;
            _compSubRepo = compSubRepo;
            _subRepo = subRepo;
            _resourceRepo = resourceRepo;
            _floorRepo = floorRepo;
            _historyRepo = historyRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<IEnumerable<CompanyDetails>>> GetAllAsync()
        {
            var res =await  _companyRepo.GetAllAsync();
            if (res == null || !res.Any())
                return new Response<IEnumerable<CompanyDetails>>(404, "no client companies", res);
            return new Response<IEnumerable<CompanyDetails>>(200, "companies found", res);
        }
        public async Task<Response<object>> NewCompany(NewCompanyDto dto)
        {
            CompanyDetails newCompany = null!;
            CompanySubscription newCompanySubscription = null!;
            Subscription? subPlan ;
            double totalAmount = 0;

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var existing = await _companyRepo
                    .SingleOrDefaultAsync(x => x.Name == dto.Name && !x.IsDeleted);

                if (existing != null)
                    return new Response<object>(409, "Company with same name already exists");

                var existingUser = await _userRepo
                    .SingleOrDefaultAsync(x => x.Email == dto.Email && !x.IsDeleted);

                if (existingUser != null)
                    return new Response<object>(409, "User already exists with this email");

                newCompany = await _companyRepo.AddAsync(new CompanyDetails
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    IsActive = false
                });

                await _userRepo.AddAsync(new User
                {
                    CompanyId = newCompany.CompanyId,
                    UserName = newCompany.Name,
                    Email = dto.Email.Trim(),
                    PassWord = BCrypt.Net.BCrypt.HashPassword(dto.PassWord),
                    RoleEnum = RoleEnum.CompanyAdmin,
                    IsActive = false,
                    IsBlocked = false
                });

                subPlan = await _subRepo.GetByIdAsync(dto.SelectedSubscriptionId);

                var startDate = newCompany.CreatedAt;
                DateTime endDate;

                if (dto.ExpirationYear == 1)
                {
                    endDate = startDate.AddYears(1);
                    totalAmount = subPlan.PriceYearly
                }
                else
                {
                    endDate = startDate.AddMonths(dto.ExpirationMonth);
                    totalAmount = subPlan.PriceMonthly * dto.ExpirationMonth;
                }

                newCompanySubscription = await _compSubRepo.AddAsync(
                    new CompanySubscription
                    {
                        CompanyId = newCompany.CompanyId,
                        SubscriptionId = dto.SelectedSubscriptionId,
                        StartDate = startDate,
                        EndDate = endDate,
                        IsActive = false,
                        Status = SubscriptionStatus.Pending,
                        AmoutToBePaid = totalAmount
                    }
                );

                newCompany.CompanySubscriptionId = newCompanySubscription.Id;
                await _companyRepo.UpdateAsync(newCompany);

                await _unitOfWork.CommitAsync();
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new Response<object>(500, ex.Message);
            }

            return new Response<object>(
                200,
                "Company added successfully, proceed to payment",
                new
                {
                    CompanyId = newCompany.CompanyId,
                    SubscriptionName = subPlan.SubscriptionName,
                    StartDate = newCompanySubscription.StartDate,
                    EndDate = newCompanySubscription.EndDate,
                    AmountToBePaid = totalAmount,
                    Currency = "INR"
                }
            );
        }



        public async Task ActivateCompanyAsync(int companyId)
        {
            var company = await _companyRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.IsDeleted == false);
            var compSubscription = await _compSubRepo.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.IsDeleted == false);
            var user = await _userRepo.SingleOrDefaultAsync(x => x.UserName == company.Name && x.CompanyId == company.CompanyId && x.IsDeleted == false);

            if (user == null)
                throw new Exception("User not found for company");

            company.IsActive = true;
            compSubscription.IsActive = true;
            compSubscription.Status = SubscriptionStatus.Active;
            user.IsActive = true;

            var floor = new CompanyFloor

            {
                FloorName = "Default Floor",
                CompanyId = company.CompanyId,
                FloorNumber = 1,
                Map="just test"
            };

            var history = new SubscriptionHistory
            {
                CompanyId = company.CompanyId,
                SubscriptionId = compSubscription.SubscriptionId,
                CompanySubscriptionId = compSubscription.Id,

                StartDate = compSubscription.StartDate,
                EndDate = compSubscription.EndDate,

                AmountPaid = compSubscription.AmoutToBePaid,
                Currency = "INR",

                StatusEnum = compSubscription.Status,
                ChangeReasonEnum = HistoryChangeReasonEnum.Initial_Purchase
            };
            

            await  _unitOfWork.BeginTransactionAsync();
            try
            {
                await _floorRepo.AddAsync(floor);
                await _companyRepo.UpdateAsync(company);
                await _compSubRepo.UpdateAsync(compSubscription);
                await _userRepo.UpdateAsync(user);
                await _historyRepo.AddAsync(history);

                await _unitOfWork.CommitAsync();
               
            
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }
    }
}
