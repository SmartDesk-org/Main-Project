using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IFloorService
    {
        Task<ApiResponse<FloorDto>> CreateFloorAsync(CreateFloorDto createFloorDto);
        Task<ApiResponse<FloorDto>> GetFloorByIdAsync(int id);
        Task<ApiResponse<List<FloorDto>>> GetAllFloorsAsync(int companyId);
        Task<ApiResponse<FloorDto>> UpdateFloorAsync(int id, UpdateFloorDto updateFloorDto);
        Task<ApiResponse<bool>> DeleteFloorAsync(int id);
        Task<ApiResponse<FloorDto>> UpdateFloorLayoutAsync(int id, FloorLayoutDto layoutDto);
    }
}
