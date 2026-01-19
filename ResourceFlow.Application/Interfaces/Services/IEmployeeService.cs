using Microsoft.AspNetCore.Http;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Common;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<ApiResponse<BulkUploadResponse>> BulkUploadAsync(IFormFile file, int companyId,int userId);
        byte[] GenerateEmployeeUploadTemplate();
        Task<ApiResponse<object>> CreateEmployeeAsync(EmployeeImportDto dto, int companyId);
        Task<Response<IEnumerable<EmployeeGetAllDto>>> GetAllEmployees();
        Task<ApiResponse<object>> UpdateEmployeeAsync(int employeeId, UpdateEmployeeDto dto, int companyId);
        Task<ApiResponse<object>> DeleteEmployeeAsync(int employeeId, int companyId);
        Task<Response<PagedResultDto<EmployeeGetAllDto>>> GetEmployeesPaginatedAsync(int companyId,int pageNumber, int pageSize, string? searchTerm);
    }

}
