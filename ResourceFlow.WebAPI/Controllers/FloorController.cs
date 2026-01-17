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

        [Authorize(Roles =Roles.CompanyAdmin.ToString())]
        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDto dto)
        {
            _logger.LogInformation(
                "CreateFloor request started. CompanyId: "
                
            );

            try
            {
                var userId = User.GetUserId();
                var floorId = await _floorService.CreateFloorAsync(dto,userId);

                _logger.LogInformation(
                    "Floor created successfully. FloorId: {FloorId}, CompanyId: ",
                    floorId
                );

                return Ok(new { FloorId = floorId });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating floor. CompanyId: "
                );
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFloors()
        {
            _logger.LogInformation(
                "GetFloors request started "

            );

            try
            {
                var userId = User.GetUserId();
                var floors = await _floorService.GetFloorsAsync(userId);

                _logger.LogInformation(
                    "GetFloors request completed. CompanyId: {userId}, FloorsCount: {Count}",
                    userId, 1
                    //floors?.Count() ?? 0
                );

                return Ok(floors);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching floors. userId: "
                    
                );
                throw;
            }
        }
    }
}
