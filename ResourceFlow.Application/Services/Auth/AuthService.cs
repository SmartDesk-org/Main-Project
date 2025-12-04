using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.Authntication;
using ResourceFlow.Infrastructure.Ef.Repositories;
using BCrypt.Net;

namespace ResourceFlow.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly GenericRepository<User> _userRepo;
        private readonly AuthRepository _authRepo;
        private readonly JwtService _jwtService;
        private readonly IConfiguration _config;
        private readonly IEmailService? _emailService;

        public AuthService(GenericRepository<User> userRepo, AuthRepository authRepo, JwtService jwtService, IConfiguration config, IEmailService? emailService = null)
        {
            _userRepo = userRepo;
            _authRepo = authRepo;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            var existing = await _userRepo.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (existing != null) throw new Exception("Email already registered");

            var user = new User
            {
                Email = dto.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RoleId = dto.RoleId
            };

            await _userRepo.AddAsync(user);

            var (token, exp) = _jwtService.GenerateAccessToken(user);
            var refresh = _jwtService.GenerateRefreshToken();
            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userRepo.UpdateAsync(user);

            return new AuthResponseDto
            {
                AccessToken = token,
                AccessTokenExpiry = exp,
                RefreshToken = refresh,
                RefreshTokenExpiry = user.RefreshTokenExpiry,
                Email = user.Email
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var user = await _authRepo.GetByEmailAsync(dto.Email);
            if (user == null) throw new Exception("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PassWord))
                throw new Exception("Invalid credentials");

            var (token, exp) = _jwtService.GenerateAccessToken(user);
            var refresh = _jwtService.GenerateRefreshToken();
            user.RefreshToken = refresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _authRepo.SaveAsync();

            return new AuthResponseDto
            {
                AccessToken = token,
                AccessTokenExpiry = exp,
                RefreshToken = refresh,
                RefreshTokenExpiry = user.RefreshTokenExpiry,
                Email = user.Email
            };
        }

        public async Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepo.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow) return null;

            var (token, exp) = _jwtService.GenerateAccessToken(user);
            var newRefresh = _jwtService.GenerateRefreshToken();
            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userRepo.UpdateAsync(user);

            return new AuthResponseDto
            {
                AccessToken = token,
                AccessTokenExpiry = exp,
                RefreshToken = newRefresh,
                RefreshTokenExpiry = user.RefreshTokenExpiry,
                Email = user.Email
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

            // Compose reset link (example)
            var frontendUrl = _config["Frontend:BaseUrl"] ?? "http://localhost:4200";
            var resetLink = $"{frontendUrl}/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(email)}";

            // send email (if email service configured)
            if (_emailService != null)
            {
                var html = $"Click to reset your password: <a href=\"{resetLink}\">{resetLink}</a>";
                await _emailService.SendAsync(email, "Reset your password", html);
            }

            // If no email service, we still return true and the caller can show token (for development)
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
