using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.Services.Floors;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FloorController : ControllerBase
    {
        private readonly FloorService _floorService;

        public FloorController(FloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDto dto)
        {
            var floorId = await _floorService.CreateFloorAsync(dto);
            return Ok(new { FloorId = floorId });
        }

        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetFloors(int companyId)
        {
            var floors = await _floorService.GetFloorsAsync(companyId);
            return Ok(floors);
        }
    }
}
