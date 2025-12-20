using ResourceFlow.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface
    IUserDapperRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByPasswordResetTokenAsync(string token);
        Task<User> GetByRefreshToken(string RefreshToken);
        Task<User> GetByUserIdAsync(int id);
        Task<int?> GetCompanyId(int userId);

    }
}
