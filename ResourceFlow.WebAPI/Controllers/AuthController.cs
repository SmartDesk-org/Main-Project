using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Services;
using ResourceFlow.Infrastructure.Extensions;
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

        // ----------------------------------------------------
        // REGISTER
        // ----------------------------------------------------
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var res = await _auth.RegisterAsync(dto);
                return StatusCode(res.StatusCode,res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

 
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        //{
        //    try
        //    {
        //        var res = await _auth.LoginAsync(dto);

        //        if (res.Data is AuthTokensDTO data && !string.IsNullOrEmpty(data.RefreshToken))
        //        {
        //            Response.Cookies.Append("refreshToken", data.RefreshToken, new CookieOptions
        //            {
        //                HttpOnly = true,
        //                Secure = true,
        //                SameSite = SameSiteMode.Strict,
        //                Expires = DateTime.UtcNow.AddDays(7)
        //            });
        //        }

        //        return StatusCode(res.StatusCode, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}


        //[HttpPost("refresh-token")]
        //public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        //{
        //    try
        //    {
        //        var res = await _auth.RefreshTokenAsync(refreshToken);

    
        



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {try{
            var res = await _auth.LoginAsync(dto);
            var data = res.Data as AuthTokensDto;

                if (res.Data is AuthTokensDTO tokens)
                {
                   
                    if (!string.IsNullOrEmpty(tokens.RefreshToken))
                    {
                        Response.Cookies.Append("refreshToken", tokens.RefreshToken, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddDays(7)
                        });
                    }
                }

                return StatusCode(res.StatusCode, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
    }





     
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

   
        [Authorize]
        [HttpPost("logout/{userId}")]
        public async Task<IActionResult> Logout(int userId)
        {
            var result = await _auth.LogoutAsync(userId);

            await _auth.LogoutAsync(userId);
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");


            return StatusCode(result.StatusCode, result);

            return Ok(new { message = "Logged out" });

        }




        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var result = await _auth.ForgotPasswordAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

      
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            
            if (!string.IsNullOrWhiteSpace(dto.Token))
            {
                var result = await _auth.ResetPasswordAsync(dto, null); 
                return StatusCode(result.StatusCode, result);
            }

            
            int userId = User.GetUserId(); 
            var result2 = await _auth.ResetPasswordAsync(dto, userId);
            return StatusCode(result2.StatusCode, result2);
        }





    }
}
