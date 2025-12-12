using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string Email { get; }
        int RoleId { get; }
        int? CompanyId { get; }
        string Username { get; }
        bool IsAuthenticated { get; }
        bool IsInRole(string role);
    }
}
