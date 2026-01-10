using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.CompanyManagement.Floor;
using ResourceFlow.Application.Interfaces.Services;
using System.Security.Claims;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] CreateFloorDto createFloorDto)
        {
            var result = await _floorService.CreateFloorAsync(createFloorDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFloor(int id)
        {
            var result = await _floorService.GetFloorByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetCompanyFloors(int companyId)
        {
            var result = await _floorService.GetAllFloorsAsync(companyId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFloor(int id, [FromBody] UpdateFloorDto updateFloorDto)
        {
            var result = await _floorService.UpdateFloorAsync(id, updateFloorDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloor(int id)
        {
            var result = await _floorService.DeleteFloorAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}/layout")]
        public async Task<IActionResult> UpdateFloorLayout(int id, [FromBody] FloorLayoutDto layoutDto)
        {
            var result = await _floorService.UpdateFloorLayoutAsync(id, layoutDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}