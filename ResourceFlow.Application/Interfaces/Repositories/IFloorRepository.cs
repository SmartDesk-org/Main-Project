using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface IFloorRepository : IGenericRepository<CompanyFloor>
    {
        Task<CompanyFloor?> GetFloorWithResourcesAsync(int floorId);
        Task<List<CompanyFloor>> GetCompanyFloorsAsync(int companyId);
    }

}
