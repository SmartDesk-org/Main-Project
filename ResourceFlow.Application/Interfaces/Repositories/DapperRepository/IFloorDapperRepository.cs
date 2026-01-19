using ResourceFlow.Application.DTOs.Floors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public  interface IFloorDapperRepository
    {
        Task<IEnumerable<FloorDto>> GetFloorsAsync(int companyId);
    }
}
