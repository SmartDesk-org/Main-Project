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

        [AllowAnonymous]
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

        [AllowAnonymous]
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
            Console.WriteLine("_________________"); Console.WriteLine("from auth controller"); Console.WriteLine(res?.Data?.AccessToken);

            return StatusCode(res.StatusCode, res);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            try
            {
                _logger.LogInformation("Refresh token API called");

                var refreshToken = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogWarning("Refresh token missing in cookie");
                    return Unauthorized("No refresh token provided");
                }

                var res = await _auth.RefreshTokenAsync(refreshToken);

                if (res == null || res.Data == null)
                {
                    _logger.LogWarning("Refresh token invalid or expired");
                    // Important: Delete the bad cookie so the client stops sending it
                    Response.Cookies.Delete("refreshToken");
                    return Unauthorized();
                }

                // Set new Refresh Token
                Response.Cookies.Append("refreshToken", res.Data.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // Set to true in Production
                    SameSite = SameSiteMode.Lax,
                    Expires = res.Data.RefreshTokenExpiry
                });

                _logger.LogInformation("Refresh token successful");
                return Ok(res.Data.AccessToken); // Return 200 OK
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh");
                return Unauthorized(); // Return 401 instead of crashing with 500
            }
        }


        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            int userId = User.GetUserId();
            _logger.LogInformation("Logout API called. UserId: {UserId}", userId);


            var result = await _auth.LogoutAsync(userId);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Path = "/"
            };

            Response.Cookies.Delete("refreshToken", cookieOptions);

            _logger.LogInformation("Logout completed. UserId: {UserId}", userId);

            return Ok(result);
        }


        [AllowAnonymous]

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            _logger.LogInformation("Forgot password API called. Email: {Email}", dto?.Email);

            var result = await _auth.ForgotPasswordAsync(dto);

            _logger.LogInformation("Forgot password completed. StatusCode: {StatusCode}", result.StatusCode);

            return StatusCode(result.StatusCode, result);
        }


        [AllowAnonymous]
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
