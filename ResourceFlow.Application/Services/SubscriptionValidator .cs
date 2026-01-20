using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Enums.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Company;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;

namespace ResourceFlow.Application.Services
{
    public sealed class SubscriptionValidator : ISubscriptionValidationService
    {
        private readonly ICompanyDapperRepository _companyRepository;
        private readonly ICompanySubscriptionDapperRepository _companySubscriptionRepository;
        private readonly IResourceUsageDapperRepository _usageRepo;
        private readonly ISubscriptionDapperRepository _subscriptionRepository;
        private readonly ILogger<SubscriptionValidator> _logger;

        public SubscriptionValidator(
            ICompanyDapperRepository companyRepository,
            ICompanySubscriptionDapperRepository companySubscriptionRepository,
            IResourceUsageDapperRepository usageRepo,
            ISubscriptionDapperRepository subscriptionRepository,
            ILogger<SubscriptionValidator> logger)
        {
            _companyRepository = companyRepository;
            _companySubscriptionRepository = companySubscriptionRepository;
            _usageRepo = usageRepo;
            _subscriptionRepository = subscriptionRepository;
            _logger = logger;
        }

        public async Task ValidateAsync(
            int companyId,
            SubscriptionFeature feature,
            SubscriptionAction action)
        {
            _logger.LogInformation(
                "Subscription validation started | CompanyId: {CompanyId}, Feature: {Feature}, Action: {Action}",
                companyId, feature, action);

            // 1️⃣ Validate company
            var company = await _companyRepository.GetCompanyByCompanyId(companyId)
                ?? throw new CompanyNotFoundException(companyId);

            if (!company.IsActive)
                throw new CompanyInactiveException(companyId);

            // 2️⃣ Validate active subscription
            var companySubscription =
                await _companySubscriptionRepository.GetActiveByCompanyIdAsync(companyId)
                ?? throw new SubscriptionNotFoundException(companyId);

            var subscription =
                await _subscriptionRepository.GetByIdAsync(companySubscription.SubscriptionId)
                ?? throw new SubscriptionNotFoundException(companyId);

            // 3️⃣ Validate expiry and grace period
            var now = DateTime.UtcNow;

            if (companySubscription.EndDate < now)
            {
                if (!subscription.IsInGracePeriod(companySubscription.EndDate))
                    throw new SubscriptionExpiredException(companyId);

                if (action != SubscriptionAction.Read)
                    throw new GracePeriodViolationException();
            }

            // 4️⃣ Only CREATE consumes plan limits
            if (action != SubscriptionAction.Create)
            {
                _logger.LogInformation(
                    "Action does not consume subscription limits. Skipping validation.");
                return;
            }

            // 5️⃣ Booking does NOT consume limits
            if (feature == SubscriptionFeature.MeetingRoomBooking)
            {
                _logger.LogInformation(
                    "Meeting room booking detected. Skipping plan limit validation.");
                return;
            }

            // 6️⃣ Count current usage
            var used = await _usageRepo.GetCountAsync(companyId, feature);

            // 7️⃣ Resolve allowed limits
            var allowed = feature switch
            {
                SubscriptionFeature.Desk => companySubscription.DesksLimit,
                SubscriptionFeature.Employee => companySubscription.EmployeesLimit,
                SubscriptionFeature.Floor => companySubscription.FloorsLimit,
                SubscriptionFeature.MeetingRoom => companySubscription.MeetingRoomsLimit,

                _ => throw new InvalidOperationException(
                        $"Unsupported subscription feature: {feature}")
            };

            //_logger.LogInformation(
            //    "Plan usage validated | CompanyId: {CompanyId}, Feature: {Feature}, Used: {Used}, Allowed: {Allowed}",
            //    companyId, feature, used, allowed);

            // 8️⃣ Enforce limits
            if (used >= allowed)
            {
                _logger.LogWarning(
                    "Plan limit exceeded | CompanyId: {CompanyId}, Feature: {Feature},Allowed={Allowed}",
                    companyId, feature,allowed);

               throw new PlanLimitExceededException(feature);
            }

            _logger.LogInformation(
                "Subscription validation completed successfully | CompanyId: {CompanyId}",
                companyId);
        }
    }
}
