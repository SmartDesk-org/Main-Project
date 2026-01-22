using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.Interfaces.History;
using ResourceFlow.Domain.Enums.Authorization;


namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;
        public HistoryController(IHistoryService service)
        {
            _service = service;
        }


        [ModuleAuthorize(ModuleCode.SHI,PermissionAction.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetHistory(int companyId)
        {
            var res = await _service.GetAllHistoryAsync(companyId);
            return StatusCode(res.StatusCode, res);
        }
    }
}
