using Microsoft.AspNetCore.Http.Features;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Booking
{
    public interface IResourceBookingService
    {
        public Task<Response<string>> CreateBookingAsync( ResourceBookingDTO dto,int resourceId,int userId);

        Task<Response<string>> CancelBookingAsync(int bookingId,int userId);

        Task<Response<List<ResourceBookingResponseDTO>>> GetBookingsByDateAsync(int userId, int resourceId, DateTime date);

        //Task<Response<> CheckAvailabilityAsync(int resourceId, DateTime startTime,DateTime endTime);

        Task<Response<string>> ReleaseBookingAsync(int bookingId, int userId, DateTime newEndTime);
        Task<Response<List<ResourceBookingResponseDTO>>> GetBookingsOfCurrentUserAsync(int userId);
        Task<Response<List<ResourceBookingResponseDTO>>> GetAllBookingsOfCompanyAsync(int userId);

        Task<Response<string>> ScanQRCodeAsync(string qrValue, int userId);

        Task<Response<List<ResourceBookingResponseDTO>>> ExpireAndGetExpiredBookingsForCompanyAsync(int userId);

        Task<Response<List<ResourceBookingResponseDTO>>>ExpireAndGetExpiredBookingsForUserAsync(int userId);

    }
}

