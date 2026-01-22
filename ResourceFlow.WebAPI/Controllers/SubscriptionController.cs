using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Application.Interfaces.Subscriptions;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Extensions;




namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
       

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
            
        }

        [ModuleAuthorize(ModuleCode.SPS,PermissionAction.Add)]
        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();    

            var res = await _service.CreatePlanAsync(dto, userId);
            return StatusCode(res.StatusCode, res);
        }


        [AllowAnonymous]
        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllPlansAsync();
            return StatusCode(res.StatusCode, res);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetPlanByIdAsync(id);
            return StatusCode(res.StatusCode,res);
        }

        [ModuleAuthorize(ModuleCode.SPS, PermissionAction.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();
            var result = await _service.UpdatePlanAsync(dto,userId,id);

            return StatusCode(result.StatusCode, result);
        }


        [ModuleAuthorize(ModuleCode.SPS, PermissionAction.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.DeletePlanAsync(id,userId);

            return StatusCode(res.StatusCode, res);
        }

        [ModuleAuthorize(ModuleCode.SPS, PermissionAction.Edit)]
        [HttpPatch("{id}/changeStatus")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.ChangeStatusAsync(id, userId);
            return StatusCode(res.StatusCode, res);
        }

        [AllowAnonymous]
        [ModuleAuthorize(ModuleCode.STY,PermissionAction.View)]
        [HttpGet("SubscriptionTypes")]
        public async Task<ActionResult> SubscriptionTypes()
        {
           var res= await _service.GetAllSubscriptionTypes();
            return StatusCode(res.StatusCode, res);
        }
    }
}
