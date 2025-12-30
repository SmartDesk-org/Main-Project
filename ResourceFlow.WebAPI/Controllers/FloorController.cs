using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FloorController> _logger;

        public FloorController(
            FloorService floorService,
            ILogger<FloorController> logger)
        {
            _floorService = floorService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDto dto)
        {
            _logger.LogInformation(
                "CreateFloor request started. CompanyId: {CompanyId}",
                dto.CompanyId
            );

            try
            {
                var floorId = await _floorService.CreateFloorAsync(dto);

                _logger.LogInformation(
                    "Floor created successfully. FloorId: {FloorId}, CompanyId: {CompanyId}",
                    floorId,
                    dto.CompanyId
                );

                return Ok(new { FloorId = floorId });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating floor. CompanyId: {CompanyId}",
                    dto.CompanyId
                );
                throw;
            }
        }

        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetFloors(int companyId)
        {
            _logger.LogInformation(
                "GetFloors request started. CompanyId: {CompanyId}",
                companyId
            );

            try
            {
                var floors = await _floorService.GetFloorsAsync(companyId);

                _logger.LogInformation(
                    "GetFloors request completed. CompanyId: {CompanyId}, FloorsCount: {Count}",
                    companyId,1
                    //floors?.Count() ?? 0
                );

                return Ok(floors);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching floors. CompanyId: {CompanyId}",
                    companyId
                );
                throw;
            }
        }
    }
}
