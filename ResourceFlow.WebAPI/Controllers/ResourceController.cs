using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Services.Resources;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourcesService _resourceService;
        private readonly ILogger<ResourceController> _logger;

        public ResourceController(
            ResourcesService resourceService,
            ILogger<ResourceController> logger)
        {
            _resourceService = resourceService;
            _logger = logger;
        }

        // 🔒 Admin – Create desk / meeting room
        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] CreateResourceDto dto)
        {
            _logger.LogInformation(
                "CreateResource request started. FloorId: {FloorId}, ResourceTypeId: {ResourceTypeId}",
                dto.FloorId,
                dto.ResourceTypeId
            );

            try
            {
                var resourceId = await _resourceService.CreateResourceAsync(dto);

                _logger.LogInformation(
                    "Resource created successfully. ResourceId: {ResourceId}, FloorId: {FloorId}",
                    resourceId,
                    dto.FloorId
                );

                return Ok(new { ResourceId = resourceId });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating resource. FloorId: {FloorId}",
                    dto.FloorId
                );
                throw;
            }
        }

        // 🔒 Admin – Drag & drop update
        [HttpPut("position")]
        public async Task<IActionResult> UpdatePosition([FromBody] UpdateResourcePositionDto dto)
        {
            _logger.LogInformation(
                "UpdateResourcePosition request started. ResourceId: {ResourceId}, X: {X}, Y: {Y}",
                dto.ResourceId,
                dto.X,
                dto.Y
            );

            try
            {
                await _resourceService.UpdatePositionAsync(dto);

                _logger.LogInformation(
                    "Resource position updated successfully. ResourceId: {ResourceId}",
                    dto.ResourceId
                );

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while updating resource position. ResourceId: {ResourceId}",
                    dto.ResourceId
                );
                throw;
            }
        }

        // 👀 Admin + Employee – View layout
        [HttpGet("floor/{floorId:int}")]
        public async Task<IActionResult> GetByFloor(int floorId)
        {
            _logger.LogInformation(
                "GetResourcesByFloor request started. FloorId: {FloorId}",
                floorId
            );

            try
            {
                var resources = await _resourceService.GetByFloorAsync(floorId);

                _logger.LogInformation(
                    "GetResourcesByFloor request completed. FloorId: {FloorId}, ResourceCount: {Count}",
                    floorId,1
                    //resources?.Count() ?? 0
                );

                return Ok(resources);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching resources for floor. FloorId: {FloorId}",
                    floorId
                );
                throw;
            }
        }

        // 🔒 Admin – Delete resource
        [HttpDelete("{resourceId:int}")]
        public async Task<IActionResult> Delete(int resourceId)
        {
            _logger.LogInformation(
                "DeleteResource request started. ResourceId: {ResourceId}",
                resourceId
            );

            try
            {
                await _resourceService.DeleteAsync(resourceId);

                _logger.LogInformation(
                    "Resource deleted successfully. ResourceId: {ResourceId}",
                    resourceId
                );

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while deleting resource. ResourceId: {ResourceId}",
                    resourceId
                );
                throw;
            }
        }
    }
}
