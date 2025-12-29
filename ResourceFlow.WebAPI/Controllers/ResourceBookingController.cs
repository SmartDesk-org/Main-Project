using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Booking;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Infrastructure.Extensions;
using ResourceFlow.Infrastructure.Services.Authorization;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceBookingController : ControllerBase
    {
        private readonly IResourceBookingService _resouBookService;
        public ResourceBookingController(IResourceBookingService resouBookService)
        {
            _resouBookService = resouBookService;
        }

        [ModuleAuthorize(ModuleCode.RBT,PermissionAction.Add)]
        [HttpPost("{resourceId}")]
        public async Task<IActionResult> CreateBooking( int resourceId, [FromBody] ResourceBookingDTO bookingDto)
        {
            var userId = User.GetUserId();

            var response = await _resouBookService.CreateBookingAsync(bookingDto,resourceId,userId);

            return StatusCode(response.StatusCode, response);
        }

        [ModuleAuthorize(ModuleCode.RBT, PermissionAction.Edit)]
        [HttpPut("{bookingId}/cancel")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var userId =User.GetUserId();

            var result = await _resouBookService.CancelBookingAsync( bookingId,userId);

            return StatusCode(result.StatusCode, result);
        }

        [ModuleAuthorize(ModuleCode.RBT,PermissionAction.View)]
        [HttpGet("{resourceId}/bookings-by-date")]
        public async Task<IActionResult> GetBookingsByDate( int resourceId,[FromQuery] DateTime date)
        {
            var userId = User.GetUserId();

            var result = await _resouBookService.GetBookingsByDateAsync(userId, resourceId,date);

            return StatusCode(result.StatusCode, result);
        }

        [ModuleAuthorize(ModuleCode.RBT,PermissionAction.Edit)]
        [HttpPatch("{bookingId}/release")]
        public async Task<IActionResult> ReleaseBooking(int bookingId, [FromBody] ReleaseBookingRequestDTO request)
        {
            var userId = int.Parse(User.FindFirst("UserId")!.Value);

            var result = await _resouBookService.ReleaseBookingAsync(
                bookingId,
                userId,
                request.NewEndTime
            );

            return StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [HttpPost("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] ScanQRCodeRequest request)
        {
            // Extract userId from JWT or session
            var userId = User.GetUserId();

            var result = await _resouBookService.ScanQRCodeAsync(request.QrValue, userId);

            return StatusCode(result.StatusCode, result.Message);
        }


        [ModuleAuthorize(ModuleCode.RBT, PermissionAction.View)]
        [HttpGet("my-bookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            int userId = User.GetUserId();

            var result = await _resouBookService.GetBookingsOfCurrentUserAsync(userId);
            return StatusCode(result.StatusCode, result);
        }


        [ModuleAuthorize(ModuleCode.RBT,PermissionAction.View)]
        [HttpGet("company-bookings")]       
        public async Task<IActionResult> GetCompanyBookings()
        {
            int userId = User.GetUserId();

            var result = await _resouBookService.GetAllBookingsOfCompanyAsync(userId);
            return StatusCode(result.StatusCode, result);
        }


    }
}