using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Repositories
{
    public class MeetingRoomRepository : GenericRepository<CompanyMeetingRoom>, IMeetingRoomRepository
    {
        private readonly AppDbContext _context;

        public MeetingRoomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Override methods
        public override async Task<CompanyMeetingRoom?> SingleOrDefaultAsync(Expression<Func<CompanyMeetingRoom, bool>> predicate)
        {
            return await _context.Set<CompanyMeetingRoom>().SingleOrDefaultAsync(predicate);
        }

        public override async Task<CompanyMeetingRoom> AddAsync(CompanyMeetingRoom entity)
        {
            await _context.Set<CompanyMeetingRoom>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(CompanyMeetingRoom entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(CompanyMeetingRoom entity)
        {
            _context.Set<CompanyMeetingRoom>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Custom methods
        public async Task<List<CompanyMeetingRoom>> GetMeetingRoomsByFloorAsync(int floorId)
        {
            return await _context.Set<CompanyMeetingRoom>()
                .Include(m => m.Floor)
                .Where(m => m.FloorId == floorId)
                .ToListAsync();
        }

        public async Task<CompanyMeetingRoom?> GetMeetingRoomWithFloorAsync(int roomId)
        {
            return await _context.Set<CompanyMeetingRoom>()
                .Include(m => m.Floor)
                .FirstOrDefaultAsync(m => m.RoomId == roomId);
        }
    }
}