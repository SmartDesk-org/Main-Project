using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using ResourceFlow.Application.Interfaces.Services;

namespace ResourceFlow.WebAPI.Controllers.CompanyManagement
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DesksController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DesksController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDesk([FromBody] CreateDeskDto createDeskDto)
        {
            var result = await _deskService.CreateDeskAsync(createDeskDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesk(int id)
        {
            var result = await _deskService.GetDeskByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("floor/{floorId}")]
        public async Task<IActionResult> GetDesksByFloor(int floorId)
        {
            var result = await _deskService.GetDesksByFloorAsync(floorId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDesk(int id, [FromBody] UpdateDeskDto updateDeskDto)
        {
            var result = await _deskService.UpdateDeskAsync(id, updateDeskDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateDeskStatus(int id, [FromBody] UpdateDeskStatusDto statusDto)
        {
            var result = await _deskService.UpdateDeskStatusAsync(id, statusDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesk(int id)
        {
            var result = await _deskService.DeleteDeskAsync(id);
            return StatusCode(result.StatusCode, result);
        }

    }
}