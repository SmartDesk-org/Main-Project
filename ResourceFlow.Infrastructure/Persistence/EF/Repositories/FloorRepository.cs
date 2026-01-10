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
    public class FloorRepository : GenericRepository<CompanyFloor>, IFloorRepository
    {
        private readonly AppDbContext _context;

        public FloorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Override methods
        public override async Task<CompanyFloor?> SingleOrDefaultAsync(Expression<Func<CompanyFloor, bool>> predicate)
        {
            return await _context.Set<CompanyFloor>().SingleOrDefaultAsync(predicate);
        }

        public override async Task<CompanyFloor> AddAsync(CompanyFloor entity)
        {
            await _context.Set<CompanyFloor>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(CompanyFloor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(CompanyFloor entity)
        {
            _context.Set<CompanyFloor>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Custom methods
        public async Task<CompanyFloor?> GetFloorWithResourcesAsync(int floorId)
        {
            return await _context.CompanyFloors
                .Include(f => f.Desks)
                .Include(f => f.MeetingRooms)
                .FirstOrDefaultAsync(f => f.FloorId == floorId && f.IsActive);
        }

        public async Task<List<CompanyFloor>> GetCompanyFloorsAsync(int companyId)
        {
            return await _context.CompanyFloors
                .Include(f => f.Desks)
                .Include(f => f.MeetingRooms)
                .Where(f => f.CompanyId == companyId && f.IsActive)
                .ToListAsync();
        }
    }
}