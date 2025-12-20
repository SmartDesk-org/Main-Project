using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Authorization;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Authorization
{
    public interface IPermissionService
    {
        Task<bool> HasPermission(int userId, ModuleCode module, PermissionAction action);
    }
}
