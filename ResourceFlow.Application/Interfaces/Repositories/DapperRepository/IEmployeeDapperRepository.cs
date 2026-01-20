using ResourceFlow.Application.DTOs.Common;
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
//<<<<<<< HEAD
//        // Task<(IEnumerable<Employees> Data, int TotalCount)>GetEmployeesPagedAsync(int companyId, int skip, int take);

//=======
        Task<PagedResultDto<EmployeeGetAllDto>> GetEmployeesPaginatedAsync(int companyId, int pageNumber, int pageSize, string? searchTerm);

    }
}
