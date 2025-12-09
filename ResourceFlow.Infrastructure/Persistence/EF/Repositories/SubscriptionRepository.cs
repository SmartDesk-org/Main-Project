using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Subscription;
using ResourceFlow.Domain.Entities.Subscription;
using ResourceFlow.Infrastructure.Persistence.EF.Context;

namespace ResourceFlow.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Plan entity)
        {
            await _context.Plans.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan?> GetByIdAsync(int id)
        {
            return await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Plan entity)
        {
            _context.Plans.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null) return false;

            _context.Plans.Remove(plan);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
