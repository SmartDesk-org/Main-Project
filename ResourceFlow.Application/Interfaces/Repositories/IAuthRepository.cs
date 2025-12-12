using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);

        Task UpdateAsync(User user);   // REQUIRED FOR PASSWORD/TOKEN UPDATE

        Task<User?> GetByResetTokenAsync(string token);

        Task SaveAsync();


        IQueryable<User> Queryable();
    }
}
