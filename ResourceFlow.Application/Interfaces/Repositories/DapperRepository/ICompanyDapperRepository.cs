using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities.SubscriptionModels;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface ICompanyDapperRepository
    {
        Task<CompanyDetails> GetAllCompany();
        Task<CompanySubscription?> GetActiveCompanySubscriptionByCompanyId(int companyId);
        Task<CompanyDetails> GetCompanyByCompanyId(int id);
    }
}
