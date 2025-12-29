using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Infrastructure.Extensions;


namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService auth, ILogger<AuthController> logger)
        {
            _auth = auth;
            _logger = logger;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            _logger.LogInformation("Register API called. Email: {Email}", dto?.Email);
            try
            {
                var res = await _auth.RegisterAsync(dto);
                _logger.LogInformation("Register completed. StatusCode: {StatusCode}", res.StatusCode);
                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                var res = await _auth.RegisterAsync(dto);
                _logger.LogError(ex, "Register failed. Email: {Email}", dto?.Email);
                return StatusCode(res.StatusCode, res);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var res = await _auth.LoginAsync(dto);

            if (res.Data != null)
            {
                Response.Cookies.Append(
                    "refreshToken",
                    res.Data.RefreshToken,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = false,
                        SameSite = SameSiteMode.Lax,
                        Expires = DateTime.UtcNow.AddDays(7)
                    }
                );
            }
            _logger.LogWarning("Login failed. Email: {Email}", dto?.Email);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {

            _logger.LogInformation("Refresh token API called");

            var refreshToken = Request.Cookies["refreshToken"];

            _logger.LogDebug("Refresh token received from cookie");

            if (string.IsNullOrEmpty(refreshToken))
            {
                _logger.LogWarning("Refresh token missing");
                return Unauthorized();
            }

            var res = await _auth.RefreshTokenAsync(refreshToken);
            if (res == null)
            {
                _logger.LogWarning("Refresh token invalid");
                return Unauthorized();
            }
            Response.Cookies.Append("refreshToken", res.Data.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = res.Data.RefreshTokenExpiry
            });

            _logger.LogInformation("Refresh token successful {token}", res.Data.RefreshToken);

            return StatusCode(200, res.Data.AccessToken);
        }


        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {

            int userId = User.GetUserId();
            _logger.LogInformation("Logout API called. UserId: {UserId}", userId);

            var result = await _auth.LogoutAsync(userId);


            await _auth.LogoutAsync(userId);

            Response.Cookies.Delete("refreshToken");


            _logger.LogInformation("Logout completed. UserId: {UserId}", userId);

            return Ok(result);
        }







        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            _logger.LogInformation("Forgot password API called. Email: {Email}", dto?.Email);

            var result = await _auth.ForgotPasswordAsync(dto);

            _logger.LogInformation("Forgot password completed. StatusCode: {StatusCode}", result.StatusCode);

            return StatusCode(result.StatusCode, result);
        }


        [EnableRateLimiting("Fixed")]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Token))
            {
                _logger.LogInformation("Reset password via token");
                var result = await _auth.ResetPasswordAsync(dto, null);
                return StatusCode(result.StatusCode, result);
            }

            int userId = User.GetUserId();
            _logger.LogInformation("Reset password for logged-in user. UserId: {UserId}", userId);

            var result2 = await _auth.ResetPasswordAsync(dto, userId);
            return StatusCode(result2.StatusCode, result2);
        }
    }
 }