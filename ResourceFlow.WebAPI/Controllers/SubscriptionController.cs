using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTO.Subscription;
using ResourceFlow.Application.Interfaces.Subscription;

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

        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreateSubscriptionDto dto)
        {
            var result = await _service.CreatePlanAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllPlansAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetPlanByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSubscriptionDto dto)
        {
            dto.Id = id;
            var result = await _service.UpdatePlanAsync(dto);

            if (!result)
                return NotFound("Plan not found");

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeletePlanAsync(id);
            if (!success) return NotFound();

            return Ok("Deleted successfully");
        }
    }
}
