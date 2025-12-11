using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Subscription;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();
            var res = await _service.CreatePlanAsync(dto,userId);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubscriptionPlanDto dto)
        {
            var userId = User.GetUserId();
            dto.SubscriptionPlanId = id;
            var result = await _service.UpdatePlanAsync(dto,userId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.GetUserId();
            var res = await _service.DeletePlanAsync(id,userId);

            return StatusCode(res.StatusCode, res);
        }
    }
}
