using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Application.Interfaces.Subscriptions;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        private readonly IPermissionService _permissionService;

        public SubscriptionController(ISubscriptionService service,IPermissionService permissionService)
        {
            _service = service;
            _permissionService = permissionService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();

            var hasPermission = await _permissionService
                .HasPermission(userId, "Subscription", "Add");

            if (!hasPermission)
                return StatusCode(StatusCodes.Status403Forbidden, new
                {
                    message = "You are not allowed to create a subscription plan"
                });

            var res = await _service.CreatePlanAsync(dto, userId);
            return StatusCode(res.StatusCode, res);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllPlansAsync();
            return StatusCode(res.StatusCode, res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetPlanByIdAsync(id);
            return StatusCode(res.StatusCode,res);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();
            var result = await _service.UpdatePlanAsync(dto,userId,id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.DeletePlanAsync(id,userId);

            return StatusCode(res.StatusCode, res);
        }

        [Authorize]
        [HttpPatch("{id}/changeStatus")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.ChangeStatusAsync(id, userId);
            return StatusCode(res.StatusCode, res);
        }

        [Authorize]
        [HttpGet("SubscriptionTypes")]
        public async Task<ActionResult> SubscriptionTypes()
        {
           var res= await _service.GetAllSubscriptionTypes();
            return StatusCode(res.StatusCode, res);
        }
    }
}
