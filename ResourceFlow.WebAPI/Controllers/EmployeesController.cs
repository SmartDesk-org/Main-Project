using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserDapperRepository _userRepo;

        public EmployeeController(IEmployeeService employeeService,IUserDapperRepository userDapperRepository)
        {
            _employeeService = employeeService;
            _userRepo = userDapperRepository;
        }
        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUpload([FromForm] EmployeeUploadRequest request)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);
        
            var result = await _employeeService.BulkUploadAsync(request.File,companyId.Value);
            return Ok(result);
        }
        [HttpGet("upload-template")]
        public IActionResult DownloadTemplate()
        {
            var fileBytes = _employeeService.GenerateEmployeeUploadTemplate();

            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(fileBytes, excelContentType, "EmployeeUploadTemplate.xlsx");
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeImportDto dto)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);
            var result = await _employeeService.CreateEmployeeAsync(dto,companyId.Value);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _employeeService.GetAllEmployees();
            return Ok(response);
        }
    }
}
