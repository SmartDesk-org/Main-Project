using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface IEmployeeDapperRepository
    {
        Task<IEnumerable<Employees>> GetEmployeeByCompanyId(int companyId);
        Task<IEnumerable<EmployeeGetAllDto>> GetAllEmployeesAsync();
        // Task<(IEnumerable<Employees> Data, int TotalCount)>GetEmployeesPagedAsync(int companyId, int skip, int take);

    }
}
