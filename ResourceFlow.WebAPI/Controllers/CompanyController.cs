using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Infrastructure.Extensions;

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
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res =await  _service.GetAllAsync();
            return StatusCode(res.StatusCode, res);
        }

        [HttpPost("NewCompany")]
        public async Task<ActionResult> NewCompany([FromBody]NewCompanyDto dto)
        {
            var res = await _service.NewCompany(dto);
            return StatusCode(res.StatusCode, res);
        }
    }
}
