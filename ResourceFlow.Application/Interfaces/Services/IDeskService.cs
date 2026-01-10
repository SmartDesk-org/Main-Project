using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IDeskService
    {
        Task<ApiResponse<DeskDto>> CreateDeskAsync(CreateDeskDto createDeskDto);
        Task<ApiResponse<DeskDto>> GetDeskByIdAsync(int id);
        Task<ApiResponse<List<DeskDto>>> GetDesksByFloorAsync(int floorId);
        Task<ApiResponse<DeskDto>> UpdateDeskAsync(int id, UpdateDeskDto updateDeskDto);
        Task<ApiResponse<DeskDto>> UpdateDeskStatusAsync(int id, UpdateDeskStatusDto statusDto);
        Task<ApiResponse<bool>> DeleteDeskAsync(int id);

    }
}
