using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface ICompanyDapperRepository
    {
        Task<CompanyDetails> GetAllCompany();
        Task<CompanySubscription?> GetActiveCompanySubscriptionByCompanyId(int companyId);
        Task<CompanyDetails> GetCompanyByCompanyId(int id);
        Task<CompanyOverview> GetCompanyOverviewAsync(int companyId);
        Task<bool> IsUserCompanyAdminAsync(int userId, int companyId);

    }
}
