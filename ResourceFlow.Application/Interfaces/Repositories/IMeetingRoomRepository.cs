using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface IMeetingRoomRepository : IGenericRepository<CompanyMeetingRoom>
    {
        Task<List<CompanyMeetingRoom>> GetMeetingRoomsByFloorAsync(int floorId);
        Task<CompanyMeetingRoom?> GetMeetingRoomWithFloorAsync(int roomId);
    }
}
