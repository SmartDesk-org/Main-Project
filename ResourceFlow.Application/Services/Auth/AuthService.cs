using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Application.Common;
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

        public AuthService(
            IGenericRepository<User> userRepo,
            IAuthRepository authRepo,
            IJwtService jwtService,
            IConfiguration config,
            IEmailService emailService,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _authRepo = authRepo;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
            _mapper = mapper;
        }

        // ----------------------------------------------------
        // REGISTER
        // ----------------------------------------------------
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            dto.Email = dto.Email.Trim().ToLower();
            dto.UserName = dto.UserName.Trim();
            dto.Password = dto.Password.Trim();

            var existing = await _userRepo.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (existing != null)
                throw new Exception("Email already registered");

            var user = _mapper.Map<User>(dto);
            user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _userRepo.AddAsync(user);

            return new AuthResponseDto(201, "User registered successfully");
        }

        // ----------------------------------------------------
        // LOGIN
        // ----------------------------------------------------
        public async Task<Response> LoginAsync(LoginRequestDto dto)
        {
            dto.Email = dto.Email?.Trim().ToLower();
            dto.Password = dto.Password?.Trim();

            var user =  await _authRepo.Queryable().Include(x => x.Role).SingleOrDefaultAsync(x => x.Email == dto.Email && x.IsDeleted == false);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PassWord))
                throw new Exception("Invalid credentials");

            var (accessToken, accessExp) = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _authRepo.SaveAsync();

            var data = new AuthTokensDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiry = accessExp,
                RefreshTokenExpiry = user.RefreshTokenExpiry,
                Role = user.Role
            };

            return new Response(200, "User logged in successfully", data);
        }

        // ----------------------------------------------------
        // REFRESH TOKEN
        // ----------------------------------------------------
        public async Task<Response?> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepo.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                return new Response(401, "Invalid or expired refresh token", null);

            var (newAccess, exp) = _jwtService.GenerateAccessToken(user);
            var newRefresh = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            await _userRepo.UpdateAsync(user);

            var data = new AuthTokensDto
            {
                AccessToken = newAccess,
                RefreshToken = newRefresh,
                AccessTokenExpiry = exp,
                RefreshTokenExpiry = user.RefreshTokenExpiry,
                Role = user.Role
            };

            return new Response(200, "Token refreshed successfully", data);
        }

        // ----------------------------------------------------
        // LOGOUT
        // ----------------------------------------------------
        public async Task<bool> LogoutAsync(int userId)
        {
            var user = await _authRepo.GetByIdAsync(userId);
            if (user == null) return false;

            user.RefreshToken = string.Empty;
            user.RefreshTokenExpiry = DateTime.MinValue;

            await _authRepo.SaveAsync();
            return true;
        }

        // ----------------------------------------------------
        // FORGOT PASSWORD
        // ----------------------------------------------------
        public async Task<bool> GenerateForgotPasswordTokenAsync(string email)
        {
            var user = await _authRepo.GetByEmailAsync(email);
            if (user == null) return false;

            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));

            user.PasswordResetToken = token;
            user.PasswordResetExpiry = DateTime.UtcNow.AddHours(1);

            await _authRepo.SaveAsync();

            var frontendUrl = _config["Frontend:BaseUrl"];
            var resetLink = $"{frontendUrl}/reset-password?token={token}&email={email}";

            if (_emailService != null)
            {
                var html = $"Click to reset: <a href=\"{resetLink}\">{resetLink}</a>";
                await _emailService.SendAsync(email, "Reset password", html);
            }

            return true;
        }

        // ----------------------------------------------------
        // RESET PASSWORD
        // ----------------------------------------------------
        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _authRepo.GetByEmailAsync(dto.Email);
            if (user == null) return false;

            if (user.PasswordResetToken != dto.Token ||
                user.PasswordResetExpiry < DateTime.UtcNow)
                return false;

            user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetExpiry = null;

            await _authRepo.SaveAsync();
            return true;
        }
    }
}
