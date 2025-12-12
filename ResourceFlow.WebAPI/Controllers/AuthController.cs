using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;

namespace ResourceFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        // ----------------------------------------------------
        // REGISTER
        // ----------------------------------------------------
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var res = await _auth.RegisterAsync(dto);
            return StatusCode(res.StatusCode, res);
        }

        // ----------------------------------------------------
        // LOGIN
        // ----------------------------------------------------
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var res = await _auth.LoginAsync(dto);
            var data = res.Data as AuthTokensDto;

            // ACCESS TOKEN COOKIE
            Response.Cookies.Append("accessToken", data.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = data.AccessTokenExpiry
            });

            // REFRESH TOKEN COOKIE
            Response.Cookies.Append("refreshToken", data.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = data.RefreshTokenExpiry
            });

            return StatusCode(res.StatusCode, res);
        }

        // ----------------------------------------------------
        // REFRESH TOKEN
        // ----------------------------------------------------
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken)) return Unauthorized();

            var res = await _auth.RefreshTokenAsync(refreshToken);
            if (res == null) return Unauthorized();

            var data = res.Data as AuthTokensDto;

            Response.Cookies.Append("accessToken", data.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = data.AccessTokenExpiry
            });

            Response.Cookies.Append("refreshToken", data.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = data.RefreshTokenExpiry
            });

            return StatusCode(res.StatusCode, res);
        }

        // ----------------------------------------------------
        // LOGOUT
        // ----------------------------------------------------
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = int.Parse(User.FindFirst("userId")?.Value ?? "0");

            await _auth.LogoutAsync(userId);
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");

            return Ok(new { message = "Logged out" });
        }

        // ----------------------------------------------------
        // FORGOT PASSWORD
        // ----------------------------------------------------
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var ok = await _auth.GenerateForgotPasswordTokenAsync(dto.Email);
            if (!ok) return NotFound(new { message = "Email not found" });

            return Ok(new { message = "Reset link sent if email exists." });
        }

        // ----------------------------------------------------
        // RESET PASSWORD
        // ----------------------------------------------------
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var ok = await _auth.ResetPasswordAsync(dto);
            if (!ok) return BadRequest(new { message = "Invalid token or expired" });

            return Ok(new { message = "Password reset successful" });
        }
    }
}
