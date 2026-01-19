using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.Interfaces.Floors;
using ResourceFlow.Application.Services.Floors;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;
        private readonly ILogger<FloorController> _logger;

        public FloorController(
            IFloorService floorService,
            ILogger<FloorController> logger)
        {
            _floorService = floorService;
            _logger = logger;
        }



        [Authorize(Roles = RoleNames.CompanyAdmin)]
        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDto dto)
        {
            _logger.LogInformation(
                "CreateFloor request started. CompanyId: "

            );
            var userId = User.GetUserId();
            var res = await _floorService.CreateFloorAsync(dto, userId);

            _logger.LogInformation(
                "Floor created successfully. FloorId: {FloorId}, CompanyId: ", res
            );

            return StatusCode(res.StatusCode, res);

        }

        [HttpGet]
        public async Task<IActionResult> GetFloors()
        {
            _logger.LogInformation(
                "GetFloors request started "

            );

            var userId = User.GetUserId();
            var res = await _floorService.GetFloorsAsync(userId);

            _logger.LogInformation(
                "GetFloors request completed. CompanyId: {userId}, FloorsCount: {Count}",
                userId,
                res.Data?.Count() ?? 0
            );

            return StatusCode(res.StatusCode, res);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFloorById(int id)
        {
            _logger.LogInformation("GetFloorById request started for FloorId: {FloorId}", id);

            var userId = User.GetUserId();
            var res = await _floorService.GetFloorByIdAsync(id, userId);

            if (res.StatusCode == 404)
            {
                _logger.LogWarning("Floor not found. FloorId: {FloorId}", id);
                return NotFound(res);
            }

            _logger.LogInformation("GetFloorById request completed successfully. FloorId: {FloorId}", id);

            return StatusCode(res.StatusCode, res);
        }
    }
}
