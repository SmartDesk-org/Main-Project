using ResourceFlow.Domain.Entities.Authentication;

namespace ResourceFlow.Application.DTOs.Auth
{
    public class AuthTokensDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpiry { get; set; }
        public int Role { get; set; } 
    }
}
