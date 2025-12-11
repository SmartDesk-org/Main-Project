using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Company
{
    public interface ICompanyService
    {
        Task<Response> NewCompany(NewCompanyDto dto);
        Task ActivateCompanyAsync(int companyId);
    }
}
