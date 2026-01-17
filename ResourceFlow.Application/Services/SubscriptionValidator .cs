using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Enums.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Company;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.SubscriptionModels;

namespace ResourceFlow.Application.Services
{
    public sealed class SubscriptionValidator : ISubscriptionValidationService
    {
        private readonly ICompanyDapperRepository _companyRepository;
        private readonly ICompanySubscriptionDapperRepository _companySubscriptionRepository;
        private readonly IResourceUsageDapperRepository _usageRepo;
        private readonly ILogger<SubscriptionValidator> _logger;
        private readonly ISubscriptionDapperRepository _subscriptionDapperRepo;
        private readonly IGenericRepository<CompanySubscription> _compSubRepo;

        public SubscriptionValidator(
            ICompanyDapperRepository companyRepository,
            ICompanySubscriptionDapperRepository companySubscriptionRepository,
            IResourceUsageDapperRepository usageRepo,
            ILogger<SubscriptionValidator> logger,
            ISubscriptionDapperRepository subscriptionDapperRepo,
            IGenericRepository<CompanySubscription> compSubRepo
            )
        {
            _companyRepository = companyRepository;
            _companySubscriptionRepository = companySubscriptionRepository;
            _usageRepo = usageRepo;
            _logger = logger;
            _subscriptionDapperRepo = subscriptionDapperRepo;
            _compSubRepo = compSubRepo;
        }

        public async Task ValidateAsync(
            int companyId,
            SubscriptionFeature feature,
            SubscriptionAction action)
        {
            _logger.LogInformation(
                "Subscription validation started. CompanyId: {CompanyId}, Feature: {Feature}, Action: {Action}",
                companyId, feature, action);

            // 1️⃣ Company validation
            var company = await _companyRepository.GetCompanyByCompanyId(companyId)
                ?? throw new CompanyNotFoundException(companyId);

            if (!company.IsActive)
                throw new CompanyInactiveException(companyId);

            // 2️⃣ Active subscription
            var companySubscription =
                await _compSubRepo.GetByIdAsync(company.CompanySubscriptionId)
                ?? throw new SubscriptionNotFoundException(companyId);

            var subscription =
                await _subscriptionDapperRepo.GetByIdAsync(companySubscription.SubscriptionId)
                ?? throw new SubscriptionNotFoundException(companyId);

            var now = DateTime.UtcNow;

            // 3️⃣ Expiry + grace period
            if (companySubscription.EndDate < now)
            {
                if (!subscription.IsInGracePeriod(companySubscription.EndDate))
                    throw new SubscriptionExpiredException(companyId);

                if (action != SubscriptionAction.Read)
                    throw new GracePeriodViolationException();
            }

            // 4️⃣ Plan usage validation (ONLY for actual resource creation)
            if (action == SubscriptionAction.Create)
            {
                // ⛔ Booking does NOT consume room limits
                if (feature == SubscriptionFeature.MeetingRoomBooking)
                {
                    _logger.LogInformation(
                        "Meeting room booking detected. Skipping plan limit validation.");
                    return;
                }

                var used = await _usageRepo.GetCountAsync(companyId, feature);

                var allowed = feature switch
                {
                    SubscriptionFeature.Desk => companySubscription.DesksLimit,
                    SubscriptionFeature.Employee => companySubscription.EmployeesLimit,
                    SubscriptionFeature.Floor => companySubscription.FloorsLimit,
                    SubscriptionFeature.MeetingRoom => companySubscription.MeetingRoomsLimit,

                    _ => throw new InvalidOperationException(
                        $"Unsupported subscription feature: {feature}")
                };

                _logger.LogInformation(
                    "Plan usage checked. CompanyId: {CompanyId}, Feature: {Feature}, Used: {Used}, Allowed: {Allowed}",
                    companyId, feature, used, allowed);

                if (used >= allowed)
                    throw new PlanLimitExceededException(feature);
            }

            _logger.LogInformation(
                "Subscription validation completed successfully. CompanyId: {CompanyId}",
                companyId);
        }
    }
}
