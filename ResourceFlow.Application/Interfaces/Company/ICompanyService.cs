using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Company
{
    public interface ICompanyService
    {
        Task<Response<IEnumerable<CompanyDetails>>> GetAllAsync();
        Task<Response<Object>> NewCompany(NewCompanyDto dto);
        Task ActivateCompanyAsync(int companyId);
        Task<Response<CompanyOverview>> GetCompanyOverviewAsync(int companyId);
        Task<Response<CompanyOverview>> GetSingleCompanyOverviewAsync(int userId);
        Task<Response<CompanySubscription>> RenewSubscription(int userId, RenewelDto dto);
    }
}
