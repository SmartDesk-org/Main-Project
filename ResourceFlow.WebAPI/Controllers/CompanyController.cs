using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Extensions;
using ResourceFlow.Infrastructure.Services.Authorization;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [ModuleAuthorize(ModuleCode.CDS,PermissionAction.View)]
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res =await  _service.GetAllAsync();
            return StatusCode(res.StatusCode, res);
        }
        [AllowAnonymous]
        [HttpPost("NewCompany")]
        public async Task<ActionResult> NewCompany([FromBody]NewCompanyDto dto)
        {
            var res = await _service.NewCompany(dto);
            return StatusCode(res.StatusCode, res);
        }


        [HttpGet("CompanyOverview")]
        public async Task<IActionResult> CompanyOverview(int companyId)
        {
            var res = await _service.GetCompanyOverview(companyId);
            return StatusCode(res.StatusCode, res);
        }
    }
}
