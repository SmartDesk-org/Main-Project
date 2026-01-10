using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface IDeskRepository : IGenericRepository<CompanyDesk>
    {
        Task<List<CompanyDesk>> GetDesksByFloorAsync(int floorId);
        Task<CompanyDesk?> GetDeskWithFloorAsync(int deskId);
    }
}
