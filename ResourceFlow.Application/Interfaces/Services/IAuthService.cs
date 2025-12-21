using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Response<object>> RegisterAsync(RegisterRequestDto dto);

        Task<AuthTokensDto> LoginAsync(LoginRequestDto dto);

        Task<Response<AuthTokensDto>> RefreshTokenAsync(string RefreshToken);

        Task<Response<object>> LogoutAsync(int userId);


        Task<Response<object>> ForgotPasswordAsync(ForgotPasswordDto dto);


        Task<Response<string>> ResetPasswordAsync(ResetPasswordDto dto, int? userId);
    }
}
