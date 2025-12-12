using Microsoft.EntityFrameworkCore;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Infrastructure.Persistence.EF.Context;

namespace ResourceFlow.Infrastructure.Ef.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly AppDbContext _db;
        public AuthRepository(AppDbContext db) { _db = db; }

        public async Task<User?> GetByEmailAsync(string email)
            => await _db.Users.SingleOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id)
            => await _db.Users.FindAsync(id);

        public async Task SaveAsync()
            => await _db.SaveChangesAsync();

        public IQueryable<User> Queryable()
        {
            return _db.Users.AsQueryable();
        }
    }
}
