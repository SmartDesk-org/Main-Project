using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Floors
{
    public  interface IFloorService
    {
        Task<Response<CompanyFloor>> CreateFloorAsync(CreateFloorDto dto);
        Task<Response<IEnumerable<FloorDto>>> GetFloorsAsync(int companyId);
    }
}
