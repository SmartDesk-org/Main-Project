using ResourceFlow.Application.DTOs.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface IResourceBookingDapperRepository
    {
        Task<IEnumerable<ResourceBookingResponseDTO>> GetBookingsByUserId(int userId);
    }
}
