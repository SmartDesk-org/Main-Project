using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Booking
{
    public interface IResourceBookingPermissionService
    {
        Task<Response<string>> CreateBookingPermissionAsync(SetResourceBookingPermissionDto dto, int userId);

        Task<Response<ResourceBookingPermissionResponseDto>>GetBookingPermissionsAsync(int companyId, int resourceTypeId);
    }
}
