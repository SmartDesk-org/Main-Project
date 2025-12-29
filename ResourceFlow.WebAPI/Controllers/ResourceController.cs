using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Services.Resources;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourcesService _resourceService;

        public ResourceController(ResourcesService resourceService)
        {
            _resourceService = resourceService;
        }

        // 🔒 Admin – Create desk / meeting room
        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] CreateResourceDto dto)
        {
            var resourceId = await _resourceService.CreateResourceAsync(dto);
            return Ok(new { ResourceId = resourceId });
        }

        // 🔒 Admin – Drag & drop update
        [HttpPut("position")]
        public async Task<IActionResult> UpdatePosition([FromBody] UpdateResourcePositionDto dto)
        {
            await _resourceService.UpdatePositionAsync(dto);
            return NoContent();
        }

        // 👀 Admin + Employee – View layout
        [HttpGet("floor/{floorId:int}")]
        public async Task<IActionResult> GetByFloor(int floorId)
        {
            var resources = await _resourceService.GetByFloorAsync(floorId);
            return Ok(resources);
        }

        // 🔒 Admin – Delete resource
        [HttpDelete("{resourceId:int}")]
        public async Task<IActionResult> Delete(int resourceId)
        {
            await _resourceService.DeleteAsync(resourceId);
            return NoContent();
        }
    }
}
