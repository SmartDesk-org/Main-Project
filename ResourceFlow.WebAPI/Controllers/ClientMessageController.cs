using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.ClientMessages;
using ResourceFlow.Application.Interfaces.ClientMessages;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums.Authorization;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMessageController : ControllerBase
    {
        private readonly IClientMessageService _service;
        public ClientMessageController(IClientMessageService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] NewClientMessageDto message)
        {
            var result = await _service.CreateAsync(message);
            return StatusCode(result.StatusCode, result);
        }

        [ModuleAuthorize(ModuleCode.CLM,PermissionAction.View)]
        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }
        [ModuleAuthorize(ModuleCode.CLM,PermissionAction.Edit)]
        [HttpPut("{id}/toggle-read")]
       
        public async Task<IActionResult> ToggleRead(int id)
        {
            var adminId = int.Parse(User.FindFirst("UserId")!.Value);

            var result = await _service.ToggleReadAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [ModuleAuthorize(ModuleCode.CLM, PermissionAction.Edit)]
        [HttpPut("{id}/toggle-important")]
       
        public async Task<IActionResult> ToggleImportant(int id)
        {
            var adminId = int.Parse(User.FindFirst("UserId")!.Value);

            var result = await _service.ToggleImportantAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [ModuleAuthorize(ModuleCode.CLM,PermissionAction.Delete)]
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var adminId = int.Parse(User.FindFirst("UserId")!.Value);

            var result = await _service.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
