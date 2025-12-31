using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ResourceFlow.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public (string token, DateTime expiry) GenerateAccessToken(User user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = jwtSettings["Secret"] ?? throw new Exception("JWT Secret missing");
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryInMinutes = int.Parse(jwtSettings["AccessTokenExpiryMinutes"] ?? "15");

            var claims = new List<Claim>
            {
                new Claim("UserEmail", user.Email),
                new Claim("userId", user.UserId.ToString()),
                new Claim("roleId", user.RoleId.ToString()),
                new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(expiryInMinutes);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

     
    }
}
