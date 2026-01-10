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
    public class DeskRepository : GenericRepository<CompanyDesk>, IDeskRepository
    {
        private readonly AppDbContext _context;

        public DeskRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Override methods
        public override async Task<CompanyDesk?> SingleOrDefaultAsync(Expression<Func<CompanyDesk, bool>> predicate)
        {
            return await _context.Set<CompanyDesk>().SingleOrDefaultAsync(predicate);
        }

        public override async Task<CompanyDesk> AddAsync(CompanyDesk entity)
        {
            await _context.Set<CompanyDesk>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(CompanyDesk entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(CompanyDesk entity)
        {
            _context.Set<CompanyDesk>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Custom methods
        public async Task<List<CompanyDesk>> GetDesksByFloorAsync(int floorId)
        {
            return await _context.Set<CompanyDesk>()
                .Include(d => d.Floor)
                .Where(d => d.FloorId == floorId)
                .ToListAsync();
        }

        public async Task<CompanyDesk?> GetDeskWithFloorAsync(int deskId)
        {
            return await _context.Set<CompanyDesk>()
                .Include(d => d.Floor)
                .FirstOrDefaultAsync(d => d.DeskId == deskId);
        }
    }
}