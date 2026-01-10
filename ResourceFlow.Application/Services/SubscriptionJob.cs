using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services
{
    public class SubscriptionJob : ISubscriptionJob
    {
        private readonly IGenericRepository<CompanySubscription> _compSubRepo;
        private readonly IGenericRepository<CompanyDetails> _compRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public SubscriptionJob(IGenericRepository<CompanySubscription> compSubRepo,
            IGenericRepository<CompanyDetails> compRepo,
            IUnitOfWork unitOfWork,
            IEmailService emailService)
        {
            _compRepo = compRepo;
            _compSubRepo = compSubRepo;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task CheckAndUpdateSubscriptionsAsync()
        {
            var now = DateTime.UtcNow;

            var expiredSubscriptions = await _compSubRepo.FindAsync(
                c => c.EndDate < now &&
                     !c.IsDeleted &&
                     c.Status == SubscriptionStatus.Active);

            if (!expiredSubscriptions.Any())
                return;

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                foreach (var subscription in expiredSubscriptions)
                {
                    if (subscription.UpcomingComSubId > 0)
                    {
                        subscription.Status = SubscriptionStatus.Renewed;

                        var upcoming = await _compSubRepo
                            .GetByIdAsync(subscription.UpcomingComSubId);

                        upcoming.IsActive = true;
                        upcoming.Status = SubscriptionStatus.Active;
                        upcoming.StartDate = now;

                        var company = await _compRepo
                            .GetByIdAsync(upcoming.CompanyId);

                        company.CompanySubscriptionId = upcoming.Id;

                        await _compSubRepo.UpdateAsync(subscription);
                        await _compSubRepo.UpdateAsync(upcoming);
                        await _compRepo.UpdateAsync(company);
                    }
                    else
                    {
                        subscription.Status = SubscriptionStatus.Expired;
                        await _compSubRepo.UpdateAsync(subscription);
                    }
                }

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw; // IMPORTANT for Hangfire retry
            }
        }

    }

}
