using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Application.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;




using Microsoft.EntityFrameworkCore;

namespace ResourceFlow.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IUserDapperRepository _userDapperRepository;
        

        public AuthService(IGenericRepository<User> userRepo, IAuthRepository authRepo, IJwtService jwtService, IConfiguration config, IEmailService emailService, IMapper mapper, IUserDapperRepository userDapperRepository) { 
       
            _userRepo = userRepo;
            _authRepo = authRepo;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
            _mapper = mapper;
            _userDapperRepository = userDapperRepository;
           
        }

        public async Task<Response<object>> RegisterAsync(RegisterRequestDto dto)
        {
            try
            {
                dto.Email = dto.Email.Trim().ToLower();
                dto.UserName = dto.UserName.Trim();
                dto.Password = dto.Password.Trim();

                if (string.IsNullOrWhiteSpace(dto.Email))
                    throw new Exception("Email is required");
                if (!dto.Email.Contains("@"))
                    throw new Exception("Invalid email format");
                if (string.IsNullOrWhiteSpace(dto.UserName))
                    throw new Exception("Username is required");
                if (string.IsNullOrWhiteSpace(dto.Password))
                    throw new Exception("Password is required");
                if (dto.Password.Length < 6)
                    throw new Exception("Password must be at least 6 characters long");
                if (dto.RoleId <= 0)
                    throw new Exception("Invalid role");

                var existing = await _userDapperRepository.GetByEmailAsync(dto.Email);
                if (existing != null)
                    throw new Exception("Email already registered");

                var user = _mapper.Map<User>(dto);
                user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.Password.Trim());
                await _userRepo.AddAsync(user);
                return new Response<object>(201, "User registered successfully");

            }
            catch (Exception ex)
            {
                return new Response<object>(500, ex.Message);

            }
           
        }

        public async Task<Response<object>> LoginAsync(LoginRequestDto dto)
        {
            try
            {
                dto.Email = dto.Email.Trim().ToLower();
                dto.Password = dto.Password.Trim();

                var user = await _userDapperRepository.GetByEmailAsync(dto.Email);
                if (user == null)
                    throw new Exception("Invalid credentials");
                if (!user.IsActive)
                    throw new Exception("Your account is inactive. Please contact admin.");
                if (user.IsBlocked)
                    throw new Exception("Your account is blocked. Please contact admin.");
                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PassWord))
                    throw new Exception("Invalid credentials");

                var (token, exp) = _jwtService.GenerateAccessToken(user);
                var refresh = _jwtService.GenerateRefreshToken();

                // Load EF entity
                var trackedUser = await _authRepo.GetByIdAsync(user.UserId);

                trackedUser.RefreshToken = refresh;
                trackedUser.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

                await _authRepo.SaveAsync();


                var res = new 
                {
                    AccessToken = token,
                    RefreshToken = refresh,
                    Role = user.RoleId
                };

                return new Response<object>(200, "User logged in successfully", res);

            }
            catch (Exception ex)
            {
                return new Response<object>(500, ex.Message);
            }
        }

        public async Task<Response<object>> RefreshTokenAsync(string RefreshToken)
        {
            try
            {
               
                var user = await _userDapperRepository.GetByRefreshToken(RefreshToken);

                if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                    return new Response<object>(401, "Invalid or expired refresh token");

               
                var dbUser = await _userDapperRepository.GetByUserIdAsync(user.UserId);

                if (dbUser == null)
                    return new Response<object>(404, "User not found");

                if (user.RefreshTokenExpiry < DateTime.UtcNow ||
                      user.RefreshTokenExpiry < DateTime.UtcNow)
                    return new Response<object>(401, "Session expired. Please login again.");


                var (accessToken, expires) = _jwtService.GenerateAccessToken(dbUser);
                var newRefreshToken = _jwtService.GenerateRefreshToken();

               
                var trackedUser = await _authRepo.GetByIdAsync(dbUser.UserId);  

                trackedUser.RefreshToken = newRefreshToken;
                trackedUser.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

                await _authRepo.SaveAsync();

                var res = new AuthTokensDto
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken,
                    AccessTokenExpiry = expires,
                    RefreshTokenExpiry = trackedUser.RefreshTokenExpiry,
                    Role = user.RoleId
                };
                // STEP 5: RETURN RESPONSE
                return new Response<object>(200, "Token refreshed",res );

            }
            catch (Exception ex)
            {
                return new Response<object>(500, ex.Message);
            }
        }



        public async Task<Response<object>> LogoutAsync(int userId)
        {
            try
            {

                var user = await _authRepo.GetByIdAsync(userId);
                if (user == null) return new Response<object>(404, "User not found.");

                user.RefreshToken = string.Empty;
                user.RefreshTokenExpiry = DateTime.MinValue;

                await _authRepo.SaveAsync();
                return new Response<object>(200, "Logout successfull.");

            }
            catch (Exception ex)
            {

                return new Response<object>(500, ex.Message);

            }
          
        }

        public async Task<Response<object>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            try
            {
                dto.Email=dto.Email.Trim().ToLower();
                var user = await _userDapperRepository.GetByEmailAsync(dto.Email);
                if (user == null)
                    return new Response<object>(404, "No user found.");

                string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));

                DateTime expiry = DateTime.UtcNow.AddMinutes(15);

                user.PasswordResetToken = token;
                user.PasswordResetExpiry = expiry;
                await _authRepo.UpdateAsync(user);

               string resetLink = $"https://your-frontend.com/reset-password?token={token}";

               await _emailService.SendPasswordResetEmailAsync(dto.Email, resetLink);


                Console.WriteLine("RESET TOKEN (DEV ONLY): " + token);

                return new Response<object>(200, "Password reset link sent to email.", token);

            }
            catch (Exception ex)
            {
                 return new Response<object>(500, ex.Message);
            }
            

        }

        public async Task<Response<string>> ResetPasswordAsync(ResetPasswordDto dto, int? userId)
        {
            try
            {
                dto.Token = dto.Token?.Trim();
                dto.CurrentPassword=dto.CurrentPassword.Trim();
                dto.NewPassword=dto.NewPassword.Trim();

                
                if (!string.IsNullOrWhiteSpace(dto.Token))
                {
                    if (string.IsNullOrWhiteSpace(dto.NewPassword))
                        return new Response<string>(400, "New password cannot be empty.");

                    var user = await _userDapperRepository.GetByPasswordResetTokenAsync(dto.Token);
                    if (user == null)
                        return new Response<string>(404, "Invalid password reset token.");
                    if (user.PasswordResetExpiry < DateTime.UtcNow)
                        return new Response<string>(400, "Password reset token has expired.");

                    user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                    user.PasswordResetToken = null;
                    user.PasswordResetExpiry = null;

                    await _authRepo.UpdateAsync(user);
                    return new Response<string>(200, "Password has been reset successfully.");
                }

                if (!userId.HasValue)
                    return new Response<string>(401, "Unauthorized");

                if (string.IsNullOrWhiteSpace(dto.CurrentPassword))
                    return new Response<string>(400, "Current password is required.");
                if (string.IsNullOrWhiteSpace(dto.NewPassword))
                    return new Response<string>(400, "New password cannot be empty.");

                var existingUser = await _userDapperRepository.GetByUserIdAsync(userId.Value);
                if (existingUser == null)
                    return new Response<string>(404, "User not found.");

                if (string.IsNullOrWhiteSpace(existingUser.PassWord))
                    return new Response<string>(400, "User has no password set.");

                if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, existingUser.PassWord))
                    return new Response<string>(400, "Current password is incorrect.");

                existingUser.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                await _authRepo.UpdateAsync(existingUser);

                return new Response<string>(200, "Password changed successfully.");
            }
            catch (Exception ex)
            {
                return new Response<string>(500, ex.Message);
            }
        }
    }
}
