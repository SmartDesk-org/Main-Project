using ResourceFlow.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Repositories.DapperRepository
{
    public interface IRoleDapperRepository
    {
        Task<Roles> GetRoleById(int RoleId);
    }
}
