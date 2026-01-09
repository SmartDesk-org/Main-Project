using DocumentFormat.OpenXml.Spreadsheet;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Booking;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.ResourceBookings
{
    public class ResourceBookingPermissionService : IResourceBookingPermissionService
    {
        private readonly IGenericRepository<CompanyResourceBookingPermission> _permissionRepo;
        private readonly IGenericRepository<User> _userRepo;

        public ResourceBookingPermissionService(IGenericRepository<CompanyResourceBookingPermission> permissionRepo, IGenericRepository<User> userRepo)
        {
            _permissionRepo = permissionRepo;
            _userRepo = userRepo;
        }

        public async Task<Response<string>> CreateBookingPermissionAsync(SetResourceBookingPermissionDto dto, int userId)
        {
            var user = await _userRepo.SingleOrDefaultAsync(
                u => u.UserId == userId && !u.IsDeleted);

            if (user == null)
                return new Response<string>(404, "User not found.");

            if (user.CompanyId == null)
                return new Response<string>(400, "User is not associated with any company.");

            var existingPermission = await _permissionRepo.SingleOrDefaultAsync(p =>
                p.CompanyId == user.CompanyId &&
                p.ResourceTypeId == dto.ResourceTypeId &&
                p.EmployeeType == dto.EmployeeTypes &&
                !p.IsDeleted);

            if (existingPermission != null)
                return new Response<string>(409, "Booking permission already exists.");

            var permission = new CompanyResourceBookingPermission
            {
                CompanyId = user.CompanyId.Value,
                ResourceTypeId = dto.ResourceTypeId,
                EmployeeType = dto.EmployeeTypes,
                CanBook = dto.CanBook,
                CreatedAt = DateTime.UtcNow
            };

            await _permissionRepo.AddAsync(permission);

            return new Response<string>(201, "Booking permission created successfully.");
        }




        public async Task<Response<ResourceBookingPermissionResponseDto>> GetBookingPermissionsAsync(int userId ,int resourceTypeId)
        {

            // 1️⃣ Resolve user and company
            var user = await _userRepo.SingleOrDefaultAsync(x =>
                x.UserId == userId && x.IsActive);

            if (user == null)
                return  new Response<ResourceBookingPermissionResponseDto>  (401, "Invalid user");

            if (!user.CompanyId.HasValue)
                return new Response<ResourceBookingPermissionResponseDto>(404, "User is not associated with any company");

            int companyId = user.CompanyId.Value;

            var permissions = await _permissionRepo.FindAsync(x =>
                x.CompanyId == companyId &&
                x.ResourceTypeId == resourceTypeId &&
                x.CanBook &&
                !x.IsDeleted);

            if (permissions == null || !permissions.Any())
                return new Response<ResourceBookingPermissionResponseDto>( 404, "Permission not found.");

            var response = new ResourceBookingPermissionResponseDto
            {
                CompanyId = companyId,
                ResourceTypeId = resourceTypeId,
                AllowedEmployeeTypes = permissions
                    .Select(p => p.EmployeeType)
                    .Distinct()
                    .ToList()
            };

            return new Response<ResourceBookingPermissionResponseDto>(200, "Permissions fetched successfully.", response);
        }

    }
}
