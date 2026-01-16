using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Extensions;
using ResourceFlow.Infrastructure.Services.Authorization;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserDapperRepository _userRepo;

        public EmployeeController(IEmployeeService employeeService, IUserDapperRepository userDapperRepository)
        {
            _employeeService = employeeService;
            _userRepo = userDapperRepository;
        }


         [ModuleAuthorize(ModuleCode.EMP,PermissionAction.Add)]
        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUpload([FromForm] EmployeeUploadRequest request)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);

            var result = await _employeeService.BulkUploadAsync(request.File, companyId.Value);
            return Ok(result);
        }


        [ModuleAuthorize(ModuleCode.EMP, PermissionAction.Add)]
        [HttpGet("upload-template")]
        public IActionResult DownloadTemplate()
        {
            var fileBytes = _employeeService.GenerateEmployeeUploadTemplate();

            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(fileBytes, excelContentType, "EmployeeUploadTemplate.xlsx");
        }


        [ModuleAuthorize(ModuleCode.EMP, PermissionAction.Add)]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeImportDto dto)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);
            var result = await _employeeService.CreateEmployeeAsync(dto, companyId.Value);
            return Ok(result);
        }


         [ModuleAuthorize(ModuleCode.EMP, PermissionAction.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var response = await _employeeService.GetAllEmployees();
            return Ok(response);
        }


        [ModuleAuthorize(ModuleCode.EMP, PermissionAction.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);
            if (companyId is null)
            {
                return Unauthorized("User is not authorized with any company!");
            }
            var result = await _employeeService.UpdateEmployeeAsync(id, dto, companyId.Value);

            return StatusCode(result.StatusCode, result);
        }


        [ModuleAuthorize(ModuleCode.EMP,PermissionAction.Delete)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = User.GetUserId();
            int? companyId = await _userRepo.GetCompanyId(userId);

            if (companyId is null)
                return Unauthorized("User is not associated with any company");

            var result = await _employeeService.DeleteEmployeeAsync(
                id,
                companyId.Value
            );

            return StatusCode(result.StatusCode, result);
        }
    }
}
