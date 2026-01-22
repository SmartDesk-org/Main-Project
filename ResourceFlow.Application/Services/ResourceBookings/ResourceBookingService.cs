
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Booking;
using ResourceFlow.Application.Interfaces.QRCode;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Booking;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Resource_Booking;
using ResourceFlow.Domain.Enums.Subscriptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using System.Security;


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


        private readonly IQRCodeService _qrCodeService;

     
        private readonly IResourceBookingDapperRepository _resourceBookingDapperRepo;

        public ResourceBookingService(IGenericRepository<Resource> resourceRepo,IGenericRepository<ResourceBooking> bookingRepo, 
                                       IGenericRepository<CompanyResourceBookingPermission> permissionRepo,IGenericRepository<Employees> employeeRepo,ISubscriptionValidationService subscriptionValidator,
                                       IGenericRepository<User> userRepo, IResourceBookingDapperRepository resourceBookingDapperRepo,IQRCodeService qRCodeService)

        {
                        _resourceRepo = resourceRepo;
                        _bookingRepo = bookingRepo;
                        _permissionRepo = permissionRepo;
                        _employeeRepo= employeeRepo;
                        _subscriptionValidator = subscriptionValidator;
                        _userRepo = userRepo;

                        _qrCodeService = qRCodeService;

                       _resourceBookingDapperRepo = resourceBookingDapperRepo;

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


                await _subscriptionValidator.ValidateAsync(
                                 companyId,
                                 SubscriptionFeature.MeetingRoomBooking,
                                 SubscriptionAction.Create
                             );


                //Employee validation
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



              // 5️⃣ Permission check
                        var permissions = await _permissionRepo.FindAsync(x =>
                            x.CompanyId == companyId &&
                            x.ResourceTypeId == dto.ResourceTypeId &&
                            x.CanBook &&
                            !x.IsDeleted);

                if (permissions.Any())
                {
                    // Convert EmployeeTypeId (int) → EmployeeTypes enum → string, then compare with Designation
                    bool hasPermission = permissions.Any(p =>
                    {
                        if (Enum.IsDefined(typeof(EmployeeTypes), p.EmployeeTypeId))
                        {
                            string permissionEmployeeType = ((EmployeeTypes)p.EmployeeTypeId).ToString();
                            return permissionEmployeeType.Equals(employee.Designation, StringComparison.OrdinalIgnoreCase);
                        }
                        return false;
                    });

                    if (!hasPermission)
                    {
                        return new Response<string>(
                            403,
                            "You are not authorized to book this resource");
                    }
                }
            




                // 6️⃣ Time validation
                var now = DateTime.UtcNow;

                if (dto.StartTime.UtcDateTime < DateTime.UtcNow)
                {
                    return new Response<string>(400, "Start time must be greater than or equal to the current time");
                }


                if (dto.StartTime >= dto.EndTime)
                    return new Response<string>(400, "Invalid time range");

                var minDuration = TimeSpan.FromMinutes(10);

                if (dto.EndTime - dto.StartTime < minDuration)
                    return new Response<string>(400, "Minimum booking duration is 10 minutes");


                var maxDuration = TimeSpan.FromHours(8);

                if (dto.EndTime - dto.StartTime > maxDuration)
                    return new Response<string>(400, "Maximum booking duration is 8 hours");

                var userOverlapExists = _bookingRepo.Queryable().Any(x =>
                                 x.BookedByUserId == userId &&
                                 x.ResourceId == resourceId &&
                                 x.Status == BookingStatus.Confirmed &&
                                 x.StartTime < dto.EndTime &&
                                 x.EndTime > dto.StartTime
 );

                if (userOverlapExists)
                {
                    return new Response<string>(
                        409,
                        "You already have a booking for this resource during the selected time range."
                    );
                }



                var overlapExists = _bookingRepo.Queryable().Any(x =>
                                 x.ResourceId == resourceId &&
                                 x.Status == BookingStatus.Confirmed &&
                                 dto.StartTime < x.EndTime &&
                                 dto.EndTime > x.StartTime
 );

                if (overlapExists)
                {
                    return new Response<string>(
                        409,
                        "Resource already booked for this time slot");
                }

                // 🔹 8️⃣ Generate QR token & expiry
                var qrValue = resource.QRCodeValue;                  // Fixed QR assigned to resource
                var qrExpiry = dto.StartTime.UtcDateTime.AddMinutes(15);


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
                    QRCodeValue = qrValue,
                    QrExpiresAt = qrExpiry,
                    IsCheckedIn = false,
                    CreatedAt = DateTime.UtcNow
                };

                await _bookingRepo.AddAsync(booking);


               

                return new Response<string>(200,"Resource booked successfully");

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


        public async Task<Response<string>> ScanQRCodeAsync(string qrValue, int userId)
        {
            var now = DateTime.UtcNow;

            // 1️⃣ Fetch booking by QR code (no time filtering yet)
            var booking = await _bookingRepo.Queryable()
                .Where(x => x.QRCodeValue == qrValue)
                .OrderByDescending(x => x.StartTime)
                .FirstOrDefaultAsync();

            if (booking == null)
                return new Response<string>(404, "Invalid QR code");

            // 2️⃣ Booking must be confirmed
            if (booking.Status != BookingStatus.Confirmed)
                return new Response<string>(400, $"Booking is {booking.Status}");

            // 3️⃣ Authorization check
            if (booking.BookedByUserId != userId)
                return new Response<string>(403, "You are not authorized to check in for this booking");

            // 4️⃣ QR expiry check
            if (now > booking.QrExpiresAt)
            {
                booking.Status = BookingStatus.Expired;
                await _bookingRepo.UpdateAsync(booking);
                return new Response<string>(400, "QR code has expired");
            }

            // 5️⃣ Time window validation
            if (now < booking.StartTime)
                return new Response<string>(400, "Check-in not started yet");

            if (now > booking.EndTime)
                return new Response<string>(400, "Booking time has already ended");

            // 6️⃣ Already checked in
            if (booking.IsCheckedIn)
                return new Response<string>(400, "Booking already checked in");

            // 7️⃣ Perform check-in
            booking.IsCheckedIn = true;
            booking.CheckInTime = now;

            await _bookingRepo.UpdateAsync(booking);

            return new Response<string>(200, "Checked in successfully");
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
                        Status = x.Status.ToString(),
                        QRCodeValue=x.QRCodeValue,
                        QrExpiresAt= x.QrExpiresAt
                     
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

                if (newEndTime.Kind != DateTimeKind.Utc)
                    return new Response<string>(400, "newEndTime must be in UTC");

                if (booking.EndTime <= now)
                    return new Response<string>(400, "Booking already ended");

                if (newEndTime <= booking.StartTime)
                    return new Response<string>(400, "New end time must be after booking start time");

                if (newEndTime >= booking.EndTime)
                    return new Response<string>(400, "New end time must be before original end time");

                var allowedSkew = TimeSpan.FromMinutes(2);
                if (newEndTime > now.Add(allowedSkew))
                    return new Response<string>(400, "Release time cannot be in the future");

                var minDuration = TimeSpan.FromMinutes(10);
                if (newEndTime - booking.StartTime < minDuration)
                    return new Response<string>(400, "Minimum booking duration is 10 minutes");

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
                var bookings = (await _resourceBookingDapperRepo
                    .GetBookingsByUserId(userId))
                    .ToList();

                if (!bookings.Any())
                {

                    return new Response<List<ResourceBookingResponseDTO>>(
                        200,
                        "No bookings found for this user",
                        new List<ResourceBookingResponseDTO>()
                    );
                }


                return new Response<List<ResourceBookingResponseDTO>>(
                    200,
                    "User bookings fetched successfully",
                    bookings
                );
            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(
                    500,
                    ex.Message
                );
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



                var companyId = user.CompanyId.Value;
                var allowedStatuses = new[]
                            {
                                BookingStatus.Confirmed,
                                BookingStatus.Pending,
                                BookingStatus.Cancelled
                            };
                // 2️⃣ Fetch bookings
                var bookings = _bookingRepo.Queryable()
                     .Where(x => x.CompanyId == companyId && allowedStatuses.Contains(x.Status)).OrderBy(x => x.StartTime)
                    .Select(x => new ResourceBookingResponseDTO
                    {
                        
                        BookingId = x.Id,
                        CompanyId = x.CompanyId,
                        UserId = userId,
                        UserName = user.UserName,
                        ResourceId = x.ResourceId,
                        ResourceTypeId = x.ResourceTypeId,
                        BookedByUserId = x.BookedByUserId,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        Status = x.Status.ToString(),
                        QrExpiresAt = x.QrExpiresAt,
                        QRCodeValue = x.QRCodeValue
                       
                    })
                    .ToList();

                return new Response<List<ResourceBookingResponseDTO>>(200, "Company bookings fetched successfully", bookings);

            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }

        }

        public async Task<Response<List<ResourceBookingResponseDTO>>> ExpireAndGetExpiredBookingsForCompanyAsync(int userId)
        {
            try
            {
                var user = await _userRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.IsActive);

                if (user == null || !user.CompanyId.HasValue)
                    return new Response<List<ResourceBookingResponseDTO>>(
                        404, "User or company not found");

                // 🔒 Role safety
                if (user.RoleId !=1)
                {
                    return new Response<List<ResourceBookingResponseDTO>>(
                        403, "Access denied");
                }

                var companyId = user.CompanyId.Value;
                var now = DateTime.UtcNow;

                // 1️⃣ Expire company bookings
                var bookingsToExpire = await _bookingRepo.Queryable()
                    .Where(b =>
                        b.CompanyId == companyId &&
                        b.EndTime <= now &&
                        b.Status != BookingStatus.Expired)
                    .ToListAsync();

                foreach (var booking in bookingsToExpire)
                {
                    booking.Status = BookingStatus.Expired;
                    booking.ModifiedAt = now;
                }

                if (bookingsToExpire.Any())
                    await _bookingRepo.SaveChangesAsync();

                // 2️⃣ Fetch expired bookings
                var expiredBookings = await _bookingRepo.Queryable()
                    .Where(b =>
                        b.CompanyId == companyId &&
                        b.Status == BookingStatus.Expired)
                    .OrderByDescending(b => b.EndTime)
                    .Select(b => new ResourceBookingResponseDTO
                    {
                        BookingId = b.Id,
                        CompanyId = b.CompanyId,
                        ResourceId = b.ResourceId,
                        ResourceTypeId = b.ResourceTypeId,
                        BookedByUserId = b.BookedByUserId,
                        StartTime = b.StartTime,
                        EndTime = b.EndTime,
                        Status = b.Status.ToString(),
                        QRCodeValue = b.QRCodeValue,
                        QrExpiresAt = b.QrExpiresAt
                    })
                    .ToListAsync();

                return new Response<List<ResourceBookingResponseDTO>>(
                    200,
                    "Company expired bookings fetched successfully",
                    expiredBookings);
            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }
        }


        public async Task<Response<List<ResourceBookingResponseDTO>>> ExpireAndGetExpiredBookingsForUserAsync(int userId)
        {
            try
            {
                var user = await _userRepo.SingleOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.IsActive);

                if (user == null)
                    return new Response<List<ResourceBookingResponseDTO>>(
                        404, "User not found");

                var now = DateTime.UtcNow;

                // 1️⃣ Expire user bookings
                var bookingsToExpire = await _bookingRepo.Queryable()
                    .Where(b =>
                        b.BookedByUserId == userId &&
                        b.EndTime <= now &&
                        b.Status != BookingStatus.Expired)
                    .ToListAsync();

                foreach (var booking in bookingsToExpire)
                {
                    booking.Status = BookingStatus.Expired;
                    booking.ModifiedAt = now;
                }

                if (bookingsToExpire.Any())
                    await _bookingRepo.SaveChangesAsync();

                // 2️⃣ Fetch expired bookings
                var expiredBookings = await _bookingRepo.Queryable()
                    .Where(b =>
                        b.BookedByUserId == userId &&
                        b.Status == BookingStatus.Expired)
                    .OrderByDescending(b => b.EndTime)
                    .Select(b => new ResourceBookingResponseDTO
                    {
                        BookingId = b.Id,
                        CompanyId = b.CompanyId,
                        ResourceId = b.ResourceId,
                        ResourceTypeId = b.ResourceTypeId,
                        BookedByUserId = b.BookedByUserId,
                        StartTime = b.StartTime,
                        EndTime = b.EndTime,
                        Status = b.Status.ToString(),
                        QRCodeValue = b.QRCodeValue,
                        QrExpiresAt = b.QrExpiresAt
                    })
                    .ToListAsync();

                return new Response<List<ResourceBookingResponseDTO>>(
                    200,
                    "User expired bookings fetched successfully",
                    expiredBookings);
            }
            catch (Exception ex)
            {
                return new Response<List<ResourceBookingResponseDTO>>(500, ex.Message);
            }
        }




    }
}
