using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);

        Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);

        Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken);

        Task<bool> LogoutAsync(int userId);

        // FORGOT PASSWORD → sends reset link with token
        Task<Response<string>> ForgotPasswordAsync(ForgotPasswordDto dto);

        // RESET PASSWORD → uses token from link
        Task<Response<string>> ResetPasswordAsync(ResetPasswordDto dto, string? email);
    }
}
