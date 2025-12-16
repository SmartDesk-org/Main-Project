using Microsoft.AspNetCore.Http;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<ApiResponse<BulkUploadResponse>> BulkUploadAsync(IFormFile file);
        byte[] GenerateEmployeeUploadTemplate();

    }

}
