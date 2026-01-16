using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public  interface IResourceDapperRepository
    {
        Task<IEnumerable<ResourceDto>> GetByFloorsAsync(int floorId);
        Task<Resource> GetByIdAsync(int resourceId);
    }
}
