using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Application.Common;

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

        public async Task<bool> GenerateForgotPasswordTokenAsync(string email)
        {
            var user = await _authRepo.GetByEmailAsync(email);
            if (user == null) return false;

            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));
            user.PasswordResetToken = token;
            user.PasswordResetExpiry = DateTime.UtcNow.AddHours(1);
            await _authRepo.SaveAsync();
            var frontendUrl = _config["Frontend:BaseUrl"] ?? "http://localhost:4200";
            var resetLink = $"{frontendUrl}/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(email)}";

            if (_emailService != null)
            {
                var html = $"Click to reset your password: <a href=\"{resetLink}\">{resetLink}</a>";
                await _emailService.SendAsync(email, "Reset your password", html);
            }
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _authRepo.GetByEmailAsync(dto.Email);
            if (user == null) return false;
            if (user.PasswordResetToken != dto.Token) return false;
            if (user.PasswordResetExpiry == null || user.PasswordResetExpiry < DateTime.UtcNow) return false;

            user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetExpiry = null;
            await _authRepo.SaveAsync();
            return true;
        }
    }
}
