using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Booking;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Extensions;


namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceBookingPermissionController : ControllerBase
    {
        private readonly IResourceBookingPermissionService _resourceBookingPermissionService;

        public ResourceBookingPermissionController(IResourceBookingPermissionService resourceBookingPermissionService)
        {
            _resourceBookingPermissionService = resourceBookingPermissionService;
        }
        [ModuleAuthorize(ModuleCode.RBP,PermissionAction.View)]
        [HttpGet]
        public async Task<IActionResult> GetPermissionTable([FromQuery] int resourceTypeId)
        {
            int userId=User.GetUserId();
            var result = await _resourceBookingPermissionService.GetBookingPermissionsAsync(userId, resourceTypeId);

            return StatusCode(result.StatusCode, result);
                
        }
        [ModuleAuthorize(ModuleCode.RBP,PermissionAction.Add)]
        [HttpPost]
        public async Task<IActionResult> AddNewPermission([FromBody]SetResourceBookingPermissionDto dto)
        {
            int userid=User.GetUserId();
            var result= await _resourceBookingPermissionService.CreateBookingPermissionAsync(dto, userid);
            return StatusCode(result.StatusCode, result);
        }
    }
}
