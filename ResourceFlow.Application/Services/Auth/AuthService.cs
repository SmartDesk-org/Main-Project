using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Application.Interfaces.Repositories;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Application.Common;
using System.Security.Claims;



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

        public AuthService(IGenericRepository<User> userRepo, IAuthRepository authRepo, IJwtService jwtService, IConfiguration config, IEmailService emailService, IMapper mapper)
        {
            _userRepo = userRepo;
            _authRepo = authRepo;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
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

            var existing = await _userRepo.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (existing != null)
                throw new Exception("Email already registered");
            var user = _mapper.Map<User>(dto);
            user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.Password.Trim());
            await _userRepo.AddAsync(user);
            return new AuthResponseDto(201, "User registered successfully");
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            dto.Email = dto.Email?.Trim().ToLower();
            dto.Password = dto.Password?.Trim();

            var user = await _authRepo.GetByEmailAsync(dto.Email);
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

            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _authRepo.SaveAsync();

            return new AuthResponseDto(200, "User logged in successfully", token, refresh)
            {
                AccessTokenExpiry = exp,
                RefreshTokenExpiry = user.RefreshTokenExpiry
            };
        }

        public async Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepo.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                return new AuthResponseDto(401, "Invalid or expired refresh token");

            var (token, exp) = _jwtService.GenerateAccessToken(user);
            var newRefresh = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userRepo.UpdateAsync(user);

            return new AuthResponseDto(200, "Token refreshed successfully", token, newRefresh)
            {
                AccessTokenExpiry = exp,
                RefreshTokenExpiry = user.RefreshTokenExpiry
            };
        }

        public async Task<bool> LogoutAsync(int userId)
        {
            var user = await _authRepo.GetByIdAsync(userId);
            if (user == null) return false;
            user.RefreshToken = string.Empty;
            user.RefreshTokenExpiry = DateTime.MinValue;
            await _authRepo.SaveAsync();
            return true;
        }

        public async Task<Response<string>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            try
            {
                var user = await _authRepo.GetByEmailAsync(dto.Email);
                if (user == null)
                    return new Response<string>(404, "No user found.");

                string token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));

                DateTime expiry = DateTime.UtcNow.AddMinutes(15);

                user.PasswordResetToken = token;
                user.PasswordResetExpiry = expiry;
                await _authRepo.UpdateAsync(user);


                string resetLink = $"https://your-frontend.com/reset-password?token={token}";


                await _emailService.SendPasswordResetEmailAsync(dto.Email, resetLink);


                Console.WriteLine("RESET TOKEN (DEV ONLY): " + token);

                return new Response<string>(200, "Password reset link sent to email.", token);

            }
            catch (Exception ex)
            {
                 return new Response<string>(500, ex.Message);
            }
            

        }

        public async Task<Response<string>> ResetPasswordAsync(ResetPasswordDto dto, string? email)
        {
            try
            {


                // 1. CASE 1 → Forgot Password (Token Provided)
                if (!string.IsNullOrEmpty(dto.Token))
                {
                    var user = await _authRepo.GetByResetTokenAsync(dto.Token);

                    if (user == null || user.PasswordResetExpiry < DateTime.UtcNow)
                        return new Response<string>(404, "Invalid or expired reset token.");

                    user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                    user.PasswordResetToken = null;
                    user.PasswordResetExpiry = null;

                    await _authRepo.UpdateAsync(user);
                    return new Response<string>(200, "Password has been reset.");
                }

                // 2. CASE 2 → Change Password (Logged-in User: CurrentPassword Required)
                if (string.IsNullOrEmpty(dto.CurrentPassword))
                    return new Response<string>(400, "Current password is required.");



                var existingUser = await _authRepo.GetByEmailAsync(email);

                if (existingUser == null)
                    return new Response<string>(404, "User not found.");

                // verify current password
                if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, existingUser.PassWord))
                    return new Response<string>(400, "Current password is incorrect.");

                existingUser.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

                await _authRepo.UpdateAsync(existingUser);
                return new Response<string>(200, "Password changed successfully.");
            }catch (Exception ex)
            {
                return new Response<string>(500, ex.Message);
            }

        }















    }
}
