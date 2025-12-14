using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Authorization
{
    public interface IPermissionService
    {
        Task<bool> HasPermission(int userId, string moduleName, string action);
    }
}
