using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Interfaces.Resources;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Infrastructure.Extensions;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourcesService _resourceService;
        private readonly ILogger<ResourceController> _logger;

        public ResourceController(
            IResourcesService resourceService,
            ILogger<ResourceController> logger)
        {
            _resourceService = resourceService;
            _logger = logger;
        }

        // 🔒 Admin – Create desk / meeting room
        [Authorize(Roles =RoleNames.CompanyAdmin)]
        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] CreateResourceDto dto)
        {
            _logger.LogInformation(
                "CreateResource request started. FloorId: {FloorId}, ResourceName: {ResourceName}",
                dto.FloorId,
                dto.ResourceName
            );


            int userId = User.GetUserId();
            var res = await _resourceService.CreateResourceAsync(dto, userId);

            _logger.LogInformation(
                "Resource created successfully. ResourceId: {ResourceId}, FloorId: {FloorId}",
                res,
                dto.FloorId
            );

            return StatusCode(res.StatusCode, res);
            
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

            var res=await _resourceService.UpdatePositionAsync(dto);

            _logger.LogInformation(
                "Resource position updated successfully. ResourceId: {ResourceId}",
                dto.ResourceId
            );

            return StatusCode(res.StatusCode, res);
            
        }

        // 👀 Admin + Employee – View layout
        [HttpGet("floor/{floorId:int}")]
        public async Task<IActionResult> GetByFloor(int floorId)
        {
            _logger.LogInformation(
                "GetResourcesByFloor request started. FloorId: {FloorId}",
                floorId
            );

            var res = await _resourceService.GetByFloorAsync(floorId);

            _logger.LogInformation(
                "GetResourcesByFloor request completed. FloorId: {FloorId}, ResourceCount: {Count}",
                floorId, 1
            //resources?.Count() ?? 0
            );

            return StatusCode(res.StatusCode, res);
           
        }

        // 🔒 Admin – Delete resource
        [HttpDelete("{resourceId:int}")]
        public async Task<IActionResult> Delete(int resourceId)
        {
            _logger.LogInformation(
                "DeleteResource request started. ResourceId: {ResourceId}",
                resourceId
            );


            var res=await _resourceService.DeleteAsync(resourceId);

            _logger.LogInformation(
                "Resource deleted successfully. ResourceId: {ResourceId}",
                resourceId
            );

            return StatusCode(res.StatusCode, res);
            
        }
    }
}
