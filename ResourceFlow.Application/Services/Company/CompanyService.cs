using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;


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
        private readonly ICompanyDapperRepository _companyDapperRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompanyService> _logger;

        private readonly IMapper _mapper;

        public CompanyService(
            IGenericRepository<CompanyDetails> companyRepo,
            IGenericRepository<User> userRepo,
            IGenericRepository<CompanySubscription> compSubRepo,
            IGenericRepository<Subscription> subRepo,
            IGenericRepository<CompanyFloor> floorRepo,
            IGenericRepository<SubscriptionHistory> historyRepo,
            IUnitOfWork unitOfWork,
            ILogger<CompanyService> logger,
            ICompanyDapperRepository companyDapperRepo,
            IMapper mapper
            )
        {
            _companyRepo = companyRepo;
            _userRepo = userRepo;
            _compSubRepo = compSubRepo;
            _subRepo = subRepo;
            _floorRepo = floorRepo;
            _historyRepo = historyRepo;
            _companyDapperRepo = companyDapperRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
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

                if (existing != null && existing.IsActive==true)
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
                    totalAmount = subPlan.PriceYearly;
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
                        AmoutToBePaid = totalAmount,
                        EmployeesLimit=subPlan.MaxEmployees,
                        FloorsLimit=subPlan.MaxFloors,
                        DesksLimit=subPlan.MaxDesks,
                        MeetingRoomsLimit=subPlan.MaxMeetingRooms
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
                Width=1200,
                Height=800,
                Scale=1,
                IsActive=true
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

                StatusEnum = SubscriptionStatus.Active,
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

        public async Task<Response<CompanyOverview>> GetCompanyOverviewAsync(int companyId)
        {
            _logger.LogInformation(
                "GetCompanyOverviewAsync started. CompanyId: {CompanyId}",
                companyId
            );

            var overview = await _companyDapperRepo.GetCompanyOverviewAsync(companyId);

            if (overview == null)
            {
                _logger.LogWarning(
                    "Company overview not found. CompanyId: {CompanyId}",
                    companyId
                );

                return new Response<CompanyOverview>(
                    404,
                    "Company overview not found"
                );
            }

            _logger.LogInformation(
                "Company overview fetched successfully. CompanyId: {CompanyId}",
                overview.EmployeesLimit
            );

            return new Response<CompanyOverview>(
                200,
                "Company overview fetched successfully",
                overview
            );
        }


        public async Task<Response<CompanyOverview>> GetSingleCompanyOverviewAsync(int userId)
        {
            _logger.LogInformation(
                "GetCompanyOverviewAsync started. userId: {userId}",
                userId
            );
            var user = await _userRepo.GetByIdAsync(userId);
            var company = await _companyDapperRepo.GetCompanyByCompanyId(user?.CompanyId??0);

            var overview = await _companyDapperRepo.GetCompanyOverviewAsync(company.CompanyId);
            Console.WriteLine("___________"); Console.WriteLine("From comp service"); 
            if (overview == null)
            {
                _logger.LogWarning(
                    "Company overview not found. CompanyId: {CompanyId}",
                    company.CompanyId
                );

                return new Response<CompanyOverview>(
                    404,
                    "Company overview not found"
                );
            }

            _logger.LogInformation(
                "Company overview fetched successfully. CompanyId: {CompanyId}",
                overview.EmployeesLimit
            );

            return new Response<CompanyOverview>(
                200,
                "Company overview fetched successfully",
                overview
            );
        }
        public async Task<Response<CompanySubscription>> RenewSubscription(int userId,RenewelDto dto)
        {
            var user =await  _userRepo.GetByIdAsync(userId);

            var company =await  _companyDapperRepo.GetCompanyByCompanyId(user?.CompanyId ?? 0);
            if (company == null )
                return new Response<CompanySubscription>(400, "Company not found ");

            bool isAdmin = await _companyDapperRepo.IsUserCompanyAdminAsync(userId, company.CompanyId);
            if (!isAdmin)
                return new Response<CompanySubscription>(403, "Only companyadmin can renew the subscription ");

            var existingComSub =await _compSubRepo.SingleOrDefaultAsync(x => x.CompanyId == company.CompanyId && x.IsDeleted==false && x.IsActive==true);
            if (existingComSub == null)
                return new Response<CompanySubscription>(400, "No subscription found for this company");

            

            var subPlan =await  _subRepo.SingleOrDefaultAsync(x => x.Id == existingComSub.SubscriptionId && x.IsActive == true && x.IsDeleted == false);

            var startDate = existingComSub.EndDate;
            var endDate = startDate;
            double?  amountToBePaid = 0;
            if (dto.ExpirationYear==1)
            {
                 endDate = startDate.AddYears(1);
                amountToBePaid = subPlan?.PriceYearly ;
            }
            else
            {
                endDate = startDate.AddMonths(dto.ExpirationMonth);
                 amountToBePaid = subPlan?.PriceMonthly*dto.ExpirationMonth;
            }

            try
            {
               await  _unitOfWork.BeginTransactionAsync();

                var newComSub = await _compSubRepo.AddAsync(new CompanySubscription
                {
                    CompanyId = company.CompanyId,
                    SubscriptionId = existingComSub.SubscriptionId,
                    StartDate = startDate,
                    EndDate = endDate,
                    AmoutToBePaid = amountToBePaid ?? 0,

                    IsActive = false,
                    Status = SubscriptionStatus.Pending,

                    EmployeesLimit = subPlan.MaxEmployees,
                    DesksLimit = subPlan.MaxDesks,
                    MeetingRoomsLimit = subPlan.MaxMeetingRooms,
                    FloorsLimit = subPlan.MaxFloors,
                    UpcomingComSubId=0

                });


                if (existingComSub.EndDate < DateTime.UtcNow)
                {
                    existingComSub.Status = SubscriptionStatus.Expired;
                    newComSub.Status = SubscriptionStatus.Active;
                    newComSub.IsActive = true;
                }
                else
                {
                    existingComSub.UpcomingComSubId = newComSub.Id;
                }

               await  _compSubRepo.UpdateAsync(existingComSub);
                await _compSubRepo.UpdateAsync(newComSub);


                await  _unitOfWork.CommitAsync();

                return new Response<CompanySubscription>(200, "renewd", newComSub);
            }
            catch(Exception e)
            {
                await _unitOfWork.RollbackAsync();
                return new Response<CompanySubscription>(200, "renewd");
            }
            
           
        }

        public async Task<Response<CompanySubscription>> ActivateRenewelAsync(int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);

            var company = await _companyDapperRepo.GetCompanyByCompanyId(user?.CompanyId ?? 0);
            if (company == null)
                return new Response<CompanySubscription>(400, "Company not found ");

            bool isAdmin = await _companyDapperRepo.IsUserCompanyAdminAsync(userId, company.CompanyId);
            if (!isAdmin)
                return new Response<CompanySubscription>(403, "Only companyadmin can renew the subscription ");

            var existingComSub = await _compSubRepo.GetByIdAsync(company.CompanySubscriptionId);
            if (existingComSub == null)
                return new Response<CompanySubscription>(400, "No subscription found for this company");

            var upcoming = await _compSubRepo.GetByIdAsync(existingComSub.UpcomingComSubId);
            if (upcoming == null)
                return new Response<CompanySubscription>(400, "No subscription found for this company");
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                upcoming.IsActive = true;
                await _compSubRepo.UpdateAsync(upcoming);

                var history=await _historyRepo.AddAsync(new SubscriptionHistory
                {
                    CompanyId = company.CompanyId,
                    SubscriptionId = upcoming.SubscriptionId,
                    CompanySubscriptionId = upcoming.Id,

                    StartDate = upcoming.StartDate,
                    EndDate = upcoming.EndDate,

                    AmountPaid = upcoming.AmoutToBePaid,
                    Currency = "INR",

                    StatusEnum = SubscriptionStatus.Renewed,
                    ChangeReasonEnum = HistoryChangeReasonEnum.Renewal
                });

                await _unitOfWork.CommitAsync();

                return new Response<CompanySubscription>(200, "Renewel completed", upcoming);

                
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return new Response<CompanySubscription>(200, "Renewel completed");
            }
        }
    }
}
