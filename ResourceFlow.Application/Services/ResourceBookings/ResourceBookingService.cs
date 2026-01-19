
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Booking;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Booking;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Resource_Booking;
using ResourceFlow.Domain.Enums.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;


namespace ResourceFlow.Application.Services.ResourceBookings
{
    public class ResourceBookingService : IResourceBookingService
    {
        private readonly IGenericRepository<Resource> _resourceRepo;
        private readonly IGenericRepository<ResourceBooking> _bookingRepo;
        private readonly IGenericRepository<CompanyResourceBookingPermission> _permissionRepo;
        private readonly IGenericRepository<Employees> _employeeRepo;
        private readonly ISubscriptionValidationService _subscriptionValidator;
        private readonly IGenericRepository<User> _userRepo;

        public ResourceBookingService(IGenericRepository<Resource> resourceRepo, IGenericRepository<ResourceBooking> bookingRepo,
                                       IGenericRepository<CompanyResourceBookingPermission> permissionRepo, IGenericRepository<Employees> employeeRepo, ISubscriptionValidationService subscriptionValidator,
                                       IGenericRepository<User> userRepo)
        {
            _resourceRepo = resourceRepo;
            _bookingRepo = bookingRepo;
            _permissionRepo = permissionRepo;
            _employeeRepo = employeeRepo;
            _subscriptionValidator = subscriptionValidator;
            _userRepo = userRepo;
        }

        public async Task<Response<string>> CreateBookingAsync(ResourceBookingDTO dto, int resourceId, int userId)
        {
            try
            {
                // 1️⃣ Resolve user and company
                var user = await _userRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId && x.IsActive);

                if (user == null)
                    return new Response<string>(401, "Invalid user");

                if (!user.CompanyId.HasValue)
                    return new Response<string>(200, "User is not associated with any company");

                var companyId = user.CompanyId.Value;

                // 2️⃣ Subscription validation
                // await _subscriptionValidator.ValidateAsync(
                //     companyId,
                //     SubscriptionFeature.MeetingRoom,
                //     SubscriptionAction.Create);

                // 3️⃣ Employee validation
                var employee = await _employeeRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.CompanyId == companyId);

                if (employee == null)
                    return new Response<string>(404, "Employee not found");

                // 4️⃣ Resource validation
                var resource = await _resourceRepo.SingleOrDefaultAsync(x =>
                    x.Id == resourceId &&
                    x.CompanyId == companyId &&
                    x.IsActive &&
                    x.ResourceTypeId == dto.ResourceTypeId);

                if (resource == null)
                    return new Response<string>(404, "Resource not found or inactive");

                // 5️⃣ Permission check (ONLY for restricted resources like Meeting Room)
                var requiresPermission = await _permissionRepo.FindAsync(x =>
                    x.CompanyId == companyId &&
                    x.ResourceTypeId == dto.ResourceTypeId);

                if (requiresPermission.Any())
                {
                    var hasPermission = requiresPermission.Any(x =>
                        x.EmployeeType == employee.Designation &&
                        x.CanBook);

                    if (!hasPermission)
                        return new Response<string>(
                            403,
                            "You are not authorized to book this resource");
                }

                // 6️⃣ Time validation
                var now = DateTime.UtcNow;

                if (dto.StartTime.UtcDateTime < DateTime.UtcNow)
                {
                    return new Response<string>(400, "Start time must be greater than or equal to the current time");
                }


                if (dto.StartTime >= dto.EndTime)
                    return new Response<string>(400, "Invalid time range");

                // 7️⃣ Overlap check
                var overlapExists = _bookingRepo.Queryable().Any(x =>
                    x.ResourceId == resourceId &&
                    x.Status == BookingStatus.Confirmed &&
                    dto.StartTime < x.EndTime &&
                    dto.EndTime > x.StartTime);

                if (overlapExists)
                    return new Response<string>(
                        409,
                        "Resource already booked for this time slot");

                // 8️⃣ Save booking
                var booking = new ResourceBooking
                {
                    CompanyId = companyId,
                    ResourceId = resourceId,
                    ResourceTypeId = dto.ResourceTypeId,
                    BookedByUserId = userId,
                    StartTime = dto.StartTime.UtcDateTime,
                    EndTime = dto.EndTime.UtcDateTime,
                    Status = BookingStatus.Confirmed,
                    CreatedAt = DateTime.UtcNow
                };

                await _bookingRepo.AddAsync(booking);

                return new Response<string>(200, "Resource booked successfully");
            }
            catch (SubscriptionException ex)
            {
                return new Response<string>(403, ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<string>(500, ex.Message);
            }
        }


        public async Task<Response<string>> CancelBookingAsync(int bookingId, int userId)
        {
            try
            {
                var user = await _userRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId && x.IsActive);

                if (user == null)
                    return new Response<string>(401, "Invalid user");

                if (!user.CompanyId.HasValue)
                    return new Response<string>(404, "User is not associated with a company");

                var companyId = user.CompanyId.Value;

                var booking = await _bookingRepo.SingleOrDefaultAsync(x =>
                    x.Id == bookingId &&
                    x.CompanyId == companyId &&
                    x.BookedByUserId == userId);

                if (booking == null)
                    return new Response<string>(200, "Booking not found");

                if (booking.Status != BookingStatus.Confirmed)
                    return new Response<string>(400, "Booking cannot be cancelled");

                if (booking.EndTime <= DateTime.UtcNow)
                    return new Response<string>(400, "Completed bookings cannot be cancelled");

                booking.Status = BookingStatus.Cancelled;
                booking.ModifiedAt = DateTime.UtcNow;

                await _bookingRepo.UpdateAsync(booking);

                return new Response<string>(200, "Booking cancelled successfully");
            }
            catch (Exception ex)
            {
                return new Response<string>(500, ex.Message);
            }
        }

        public async Task<Response<List<ResourceBookingResponseDTO>>> GetBookingsByDateAsync(int userId, int resourceId, DateTime date)
        {
            try
            {
                // 1️⃣ Resolve companyId from user
                var user = await _userRepo.SingleOrDefaultAsync(x => x.UserId == userId && x.IsActive);
                if (user == null || !user.CompanyId.HasValue)
                    return new Response<List<ResourceBookingResponseDTO>>(404, "User not found or not associated with a company", null);

                var companyId = user.CompanyId.Value;

                // 2️⃣ Normalize date to UTC start/end of the day
                var startOfDayUtc = date.Date.ToUniversalTime();
                var endOfDayUtc = date.Date.AddDays(1).AddTicks(-1).ToUniversalTime();

                // 3️⃣ Fetch bookings overlapping that day
                var bookings = _bookingRepo.Queryable()
                    .Where(x =>
                        x.CompanyId == companyId &&
                        x.ResourceId == resourceId &&
                        x.Status == BookingStatus.Confirmed &&
                        x.StartTime < endOfDayUtc &&
                        x.EndTime > startOfDayUtc
                    )
                    .OrderBy(x => x.StartTime)
                    .Select(x => new ResourceBookingResponseDTO
                    {
                        BookingId = x.Id,
                        CompanyId = x.CompanyId,
                        ResourceId = x.ResourceId,
                        ResourceTypeId = x.ResourceTypeId,
                        BookedByUserId = x.BookedByUserId,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        Status = x.Status.ToString()
                    })
                    .ToList();

                return new Response<List<ResourceBookingResponseDTO>>(200, "Bookings fetched successfully", bookings);
            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }
        }

        public async Task<Response<string>> ReleaseBookingAsync(int bookingId, int userId, DateTime newEndTime)
        {
            try
            {
                // 1️⃣ Get booking for the user
                var booking = await _bookingRepo.SingleOrDefaultAsync(x =>
                    x.Id == bookingId &&
                    x.BookedByUserId == userId &&
                    x.Status == BookingStatus.Confirmed
                );

                if (booking == null)
                    return new Response<string>(200, "Booking not found or cannot be released");

                var now = DateTime.UtcNow;

                // 2️⃣ Validate new end time
                if (newEndTime <= booking.StartTime)
                    return new Response<string>(400, "New end time must be after booking start time");

                if (newEndTime >= booking.EndTime)
                    return new Response<string>(400, "New end time must be before original end time");

                if (newEndTime > now)
                    return new Response<string>(400, "You can only release past time"); // optional

                // 3️⃣ Shorten booking
                booking.EndTime = newEndTime;
                await _bookingRepo.UpdateAsync(booking);

                return new Response<string>(200, $"Booking released until {newEndTime:HH:mm} successfully");
            }
            catch (Exception ex)
            {
                return new Response<string>(500, ex.Message);
            }
        }


        public async Task<Response<List<ResourceBookingResponseDTO>>> GetBookingsOfCurrentUserAsync(int userId)
        {
            try
            {
                var bookings = _bookingRepo.Queryable()
               .Where(x => x.BookedByUserId == userId)
               .OrderByDescending(x => x.StartTime)
               .Select(x => new ResourceBookingResponseDTO
               {
                   BookingId = x.Id,
                   CompanyId = x.CompanyId,
                   ResourceId = x.ResourceId,
                   ResourceTypeId = x.ResourceTypeId,
                   BookedByUserId = x.BookedByUserId,
                   StartTime = x.StartTime,
                   EndTime = x.EndTime,
                   Status = x.Status.ToString()
               })
               .ToList();

                if (!bookings.Any())
                {
                    return new Response<List<ResourceBookingResponseDTO>>(200, "No bookings found for this user");
                }
                return new Response<List<ResourceBookingResponseDTO>>(200, "User bookings fetched successfully", bookings);

            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }

        }


        public async Task<Response<List<ResourceBookingResponseDTO>>> GetAllBookingsOfCompanyAsync(int userId)
        {
            try
            {
                // 1️⃣ Resolve company from user
                var user = await _userRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId && x.IsActive);

                if (user == null || !user.CompanyId.HasValue)
                    return new Response<List<ResourceBookingResponseDTO>>(200, "User or company not found");

                if (user.RoleEnum != RoleEnum.CompanyAdmin)
                {
                    return new Response<List<ResourceBookingResponseDTO>>(403, "Only company admin can access company bookings");
                }
                ;

                var companyId = user.CompanyId.Value;

                // 2️⃣ Fetch bookings
                var bookings = _bookingRepo.Queryable()
                    .Where(x => x.CompanyId == companyId)
                    .OrderBy(x => x.StartTime)
                    .Select(x => new ResourceBookingResponseDTO
                    {
                        BookingId = x.Id,
                        CompanyId = x.CompanyId,
                        ResourceId = x.ResourceId,
                        ResourceTypeId = x.ResourceTypeId,
                        BookedByUserId = x.BookedByUserId,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        Status = x.Status.ToString()
                    })
                    .ToList();

                return new Response<List<ResourceBookingResponseDTO>>(200, "Company bookings fetched successfully", bookings);

            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }

        }




    }
}
