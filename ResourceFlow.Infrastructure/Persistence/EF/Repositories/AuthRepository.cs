using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Infrastructure.Persistence.EF.Context;

namespace ResourceFlow.Infrastructure.Ef.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.Trim() == email.Trim());
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByResetTokenAsync(string token)
        {
            return await _context.Users.FirstOrDefaultAsync(
                x => x.PasswordResetToken == token && x.PasswordResetExpiry > DateTime.UtcNow
            );
        }
        public IQueryable<User> Queryable()
        {
            return _db.Users.AsQueryable();
        }
    }
}
