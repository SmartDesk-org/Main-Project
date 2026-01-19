using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Feedback;
using ResourceFlow.Application.Interfaces.Feedbacks;
using ResourceFlow.Domain.Enums;

using ResourceFlow.Domain.Enums.Authorization;

using ResourceFlow.Infrastructure.Extensions;
using ResourceFlow.Infrastructure.Services.Authorization;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackservice _service;

        public FeedbackController(IFeedbackservice service)
        {
            _service = service;
        }

        // ---------------------------------------------
        // GET ALL (Admin)
        // ---------------------------------------------
        [ModuleAuthorize(ModuleCode.FBK,PermissionAction.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return StatusCode(res.StatusCode, res);
        }

        // ---------------------------------------------
        // GET PUBLISHED (Public)
        // ---------------------------------------------
        [AllowAnonymous]
        [HttpGet("published")]
        public async Task<IActionResult> GetPublished()
        {
            var res = await _service.GetPublishedAsync();
            return StatusCode(res.StatusCode, res);
        }

        // ---------------------------------------------
        // ADD
        // ---------------------------------------------
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NewFeedbackDto dto)
        {
            var userId = User.GetUserId();
            var res = await _service.CreateAsync(dto,userId);
            return StatusCode(res.StatusCode, res);
        }

        // ---------------------------------------------
        // TOGGLE PUBLISH
        // ---------------------------------------------
        [ModuleAuthorize(ModuleCode.FBK,PermissionAction.Edit)]
        [HttpPatch("{id}/toggle-publish")]
        public async Task<IActionResult> TogglePublish(int id)
        {
            var res = await _service.TogglePublishAsync(id);
            return StatusCode(res.StatusCode, res);
        }

        // ---------------------------------------------
        // DELETE
        // ---------------------------------------------
        [ModuleAuthorize(ModuleCode.FBK,PermissionAction.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteAsync(id);
            return StatusCode(res.StatusCode, res);
        }


        
        //[Authorize(Roles =RoleNames.CompanyAdmin)]

        [ModuleAuthorize(ModuleCode.FBK,PermissionAction.View)]
        //[Authorize(Roles =RoleNames.CompanyAdmin)]

        [HttpGet("GetAllForCompany")]
        public async Task<IActionResult> GetAllForCompany(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.GetAllForCompany( userId);
            return StatusCode(res.StatusCode, res);
        }
    }
}
