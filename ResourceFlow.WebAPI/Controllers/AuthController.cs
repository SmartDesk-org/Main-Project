using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using System.Security.Claims;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var res = await _auth.RegisterAsync(dto);

                if (!string.IsNullOrEmpty(res.RefreshToken))
                {
                    Response.Cookies.Append("refreshToken", res.RefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = res.RefreshTokenExpiry
                    });
                }

                return StatusCode(res.StatusCode,res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var res = await _auth.LoginAsync(dto);

                if (!string.IsNullOrEmpty(res.RefreshToken))
                {
                    Response.Cookies.Append("refreshToken", res.RefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = res.RefreshTokenExpiry
                    });
                }

                return StatusCode(res.StatusCode,res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            // prefer cookie-based refresh token
            var refresh = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refresh)) return Unauthorized();

            var res = await _auth.RefreshTokenAsync(refresh);
            if (res == null) return Unauthorized();

            // update cookie
            Response.Cookies.Append("refreshToken", res.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = res.RefreshTokenExpiry
            });

            return StatusCode(res.StatusCode,res);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = int.Parse(User.FindFirst("userId")?.Value ?? "0");
            await _auth.LogoutAsync(userId);

            // delete cookie
            Response.Cookies.Delete("refreshToken");
            return Ok(new { message = "Logged out" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var ok = await _auth.GenerateForgotPasswordTokenAsync(dto.Email);
            if (!ok) return NotFound(new { message = "Email not found" });
            return Ok(new { message = "If email exists, reset link was sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var ok = await _auth.ResetPasswordAsync(dto);
            if (!ok) return BadRequest(new { message = "Invalid token or expired" });
            return StatusCode(200, new { message = "Password reset successful" });
        }
    }
}
