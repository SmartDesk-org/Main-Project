using ResourceFlow.Domain.Entities.Authntication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Auth
{
    public interface IJwtService
    {
        (string token, DateTime expiry) GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
