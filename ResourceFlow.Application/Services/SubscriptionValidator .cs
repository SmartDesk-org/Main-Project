using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.SubscriptionModels;
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

        public SubscriptionValidator(
            ICompanyDapperRepository companyRepository,
            ICompanySubscriptionDapperRepository companySubscriptionRepository,
            IResourceUsageDapperRepository usageRepo
            )
        {
            _companyRepository = companyRepository;
            _companySubscriptionRepository = companySubscriptionRepository;
            _usageRepo = usageRepo;
        }

        public async Task ValidateAsync(
            int companyId,
            SubscriptionFeature feature,
            SubscriptionAction action)
        {
            // 1️⃣ Company must exist and be active
            var company = await _companyRepository.GetCompanyByCompanyId(companyId)
                ?? throw new CompanyNotFoundException(companyId);

            if (!company.IsActive)
                throw new CompanyInactiveException(companyId);

            // 2️⃣ Active subscription
            var companySubscription =
                await _companySubscriptionRepository.GetActiveByCompanyIdAsync(companyId)
                ?? throw new SubscriptionNotFoundException(companyId);

            var subscription = companySubscription.Subscription
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

            if(action==SubscriptionAction.Create)
            {
                var used =await  _usageRepo.GetCountAsync(companyId, feature);
                var plan = companySubscription.Subscription;
                var allowed = plan.GetLimit(feature);

                if (used >= allowed)
                    throw new PlanLimitExceededException(feature);
            }

            // 🔒 Limits intentionally skipped for now
        }
    }
}
