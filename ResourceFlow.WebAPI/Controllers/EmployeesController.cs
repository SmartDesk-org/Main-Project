using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces.Services;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUpload([FromForm] EmployeeUploadRequest request)
        {
            var result = await _employeeService.BulkUploadAsync(request.File);
            return Ok(result);
        }
        [HttpGet("upload-template")]
        public IActionResult DownloadTemplate()
        {
            var fileBytes = _employeeService.GenerateEmployeeUploadTemplate();
            
            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(fileBytes, excelContentType, "EmployeeUploadTemplate.xlsx");
        }

    }
}
