using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Enums.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Company;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using Microsoft.Extensions.Logging;

namespace ResourceFlow.Application.Services
{
    public sealed class SubscriptionValidator : ISubscriptionValidationService
    {
        private readonly ICompanyDapperRepository _companyRepository;
        private readonly ICompanySubscriptionDapperRepository _companySubscriptionRepository;
        private readonly IResourceUsageDapperRepository _usageRepo;
        private readonly ILogger<SubscriptionValidator> _logger;
        private readonly ISubscriptionDapperRepository _subscriptionDapperRepo;

        public SubscriptionValidator(
            ICompanyDapperRepository companyRepository,
            ICompanySubscriptionDapperRepository companySubscriptionRepository,
            IResourceUsageDapperRepository usageRepo,
            ILogger<SubscriptionValidator> logger,
            ISubscriptionDapperRepository subscriptionDapperRepo
            )

        {
            _companyRepository = companyRepository;
            _companySubscriptionRepository = companySubscriptionRepository;
            _usageRepo = usageRepo;
            _logger = logger;
            _subscriptionDapperRepo = subscriptionDapperRepo;
        }

        public async Task ValidateAsync(
            int companyId,
            SubscriptionFeature feature,
            SubscriptionAction action)
        {
            _logger.LogInformation(
                "Subscription validation started. CompanyId: {CompanyId}, Feature: {Feature}, Action: {Action}",
                companyId, feature, action);

            // 1️⃣ Company must exist and be active
            _logger.LogDebug("Validating company existence. CompanyId: {CompanyId}", companyId);


            // 1️⃣ Company validation
            var company = await _companyRepository.GetCompanyByCompanyId(companyId)
                ?? throw new CompanyNotFoundException(companyId);

            if (!company.IsActive)
            {
                _logger.LogWarning("Company is inactive. CompanyId: {CompanyId}", companyId);
                throw new CompanyInactiveException(companyId);
            }

            _logger.LogDebug("Company validated successfully. CompanyId: {CompanyId}", companyId);

            // 2️⃣ Active subscription
            _logger.LogDebug("Fetching active subscription. CompanyId: {CompanyId}", companyId);

            var companySubscription =
                await _companySubscriptionRepository.GetActiveByCompanyIdAsync(companyId)
                ?? throw new SubscriptionNotFoundException(companyId);


            var subscription = await _subscriptionDapperRepo.GetByIdAsync(companySubscription.SubscriptionId)
                 ?? throw new SubscriptionNotFoundException(companyId);

            _logger.LogInformation(
                "Active subscription found. SubscriptionId: {SubscriptionId}, EndDate: {EndDate}",
                subscription.Id, companySubscription.EndDate);




            var now = DateTime.UtcNow;

            // 3️⃣ Expiry + grace period
            if (companySubscription.EndDate < now)
            {
                _logger.LogWarning(
                    "Subscription expired. CompanyId: {CompanyId}, EndDate: {EndDate}",
                    companyId, companySubscription.EndDate);

                if (!subscription.IsInGracePeriod(companySubscription.EndDate))
                {
                    _logger.LogError(
                        "Subscription fully expired (no grace period). CompanyId: {CompanyId}",
                        companyId);
                    throw new SubscriptionExpiredException(companyId);
                }

                if (action != SubscriptionAction.Read)
                {
                    _logger.LogError(
                        "Grace period violation. CompanyId: {CompanyId}, Action: {Action}",
                        companyId, action);
                    throw new GracePeriodViolationException();
                }
            }


            // 4️⃣ Plan usage validation (Create only)
            if (action == SubscriptionAction.Create)
            {
                _logger.LogDebug(
                    "Validating plan limits. CompanyId: {CompanyId}, Feature: {Feature}",
                    companyId, feature);

                //var used = await _usageRepo.GetCountAsync(companyId, feature);
                var plan = subscription;

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

                    {
                        _logger.LogWarning(
                            "Plan limit exceeded. CompanyId: {CompanyId}, Feature: {Feature}",
                            companyId, feature);
                        throw new PlanLimitExceededException(feature);
                    }

                }

                _logger.LogInformation(
                    "Subscription validation completed successfully. CompanyId: {CompanyId}",
                    companyId);
            }
        }
    }
}
