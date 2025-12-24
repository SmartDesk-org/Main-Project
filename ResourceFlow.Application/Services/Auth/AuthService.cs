using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Exceptions;
using System.Security.Claims;
using System.Security.Cryptography;


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
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IGenericRepository<User> userRepo,
            IAuthRepository authRepo,
            IJwtService jwtService,
            IConfiguration config,
            IEmailService emailService,
            IMapper mapper,
            IUserDapperRepository userDapperRepository,
            ILogger<AuthService> logger)
        {
            _userRepo = userRepo;
            _authRepo = authRepo;
            _jwtService = jwtService;
            _config = config;
            _emailService = emailService;
            _mapper = mapper;
            _userDapperRepository = userDapperRepository;
            _logger = logger;
        }

        public async Task<Response<object>> RegisterAsync(RegisterRequestDto dto)
        {
            try
            {
                _logger.LogInformation("Register attempt for email {Email}", dto.Email);

                // Normalize input (this is still OK here)
                dto.Email = dto.Email.Trim().ToLower();
                dto.UserName = dto.UserName.Trim();
                dto.Password = dto.Password.Trim();

                // ONLY business-level validation remains
                var existing = await _userDapperRepository.GetByEmailAsync(dto.Email);
                if (existing != null)
                    return new Response<object>(409, "Email already registered");

                var user = _mapper.Map<User>(dto);
                user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.Password);




                await _userRepo.AddAsync(user);

                _logger.LogInformation("User registered successfully. Email: {Email}", dto.Email);

                return new Response<object>(201, "User registered successfully");
            }
            catch (StoredProcedureException ex)
            {
                _logger.LogError(ex, "SP execution failed during password reset.");
                return new Response<object>(500, "Database error occurred. Please try again later.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed for email {Email}", dto.Email);
                return new Response<object>(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Response<AuthTokensDto>> LoginAsync(LoginRequestDto dto)
        {
            try
            {
                _logger.LogInformation("Login attempt for email {Email}", dto.Email);

                dto.Email = dto.Email.Trim().ToLower();
                dto.Password = dto.Password.Trim();

                var user = await _userDapperRepository.GetByEmailAsync(dto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PassWord))
                {
                    _logger.LogWarning("Invalid login attempt for email {Email}", dto.Email);
                    throw new Exception("Invalid credentials");
                }

                if (!user.IsActive || user.IsBlocked)
                {
                    _logger.LogWarning("Login blocked for UserId {UserId}", user.UserId);
                    throw new Exception("Account inactive or blocked");
                }

                var (accessToken, exp) = _jwtService.GenerateAccessToken(user);
                var refreshToken = _jwtService.GenerateRefreshToken();

                var trackedUser = await _authRepo.GetByIdAsync(user.UserId);
                trackedUser.RefreshToken = refreshToken;
                trackedUser.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

                await _authRepo.SaveAsync();


                _logger.LogInformation("Login successful for UserId {UserId}", user.UserId);


                var res = new AuthTokensDto


                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    //AccessTokenExpiry = exp,
                    //RefreshTokenExpiry = trackedUser.RefreshTokenExpiry,
                    //Role = user.RoleId
                };


                return new Response<AuthTokensDto>(200, "Login Succesfull", res);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed");
                throw;
            }
        }

        public async Task<AuthTokensDto> RefreshTokenAsync(string refreshToken)
        {
            try
            {

                _logger.LogInformation("Refresh token request received");


                var user = await _userDapperRepository.GetByRefreshToken(refreshToken);
                if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                {
                    _logger.LogWarning("Invalid or expired refresh token");
                    throw new Exception("Invalid or expired refresh token");
                }


                var (accessToken, exp) = _jwtService.GenerateAccessToken(user);
                var newRefreshToken = _jwtService.GenerateRefreshToken();

                var trackedUser = await _authRepo.GetByIdAsync(user.UserId);


                var dbUser = await _userDapperRepository.GetByUserIdAsync(user.UserId);

                if (dbUser == null)
                    throw new Exception("User not found");

                if (user.RefreshTokenExpiry < DateTime.UtcNow ||
                      user.RefreshTokenExpiry < DateTime.UtcNow)

                    throw new Exception("Session expired. Please login again.");
                trackedUser.RefreshToken = newRefreshToken;
                trackedUser.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

                await _authRepo.SaveAsync();


                _logger.LogInformation("Token refreshed for UserId {UserId}", user.UserId);



                var res = new AuthTokensDto

                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken,
                    AccessTokenExpiry = exp,
                    RefreshTokenExpiry = trackedUser.RefreshTokenExpiry,
                    Role = user.RoleId
                };


                _logger.LogInformation("token {token}", res.RefreshToken);
                // STEP 5: RETURN RESPONSE
                return res;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Refresh token failed");
                throw new Exception("refresh failed");
            }
        }

        public async Task<Response<object>> LogoutAsync(int userId)
        {
            try
            {
                _logger.LogInformation("Logout request for UserId {UserId}", userId);

                var user = await _authRepo.GetByIdAsync(userId);
                if (user == null)
                    return new Response<object>(404, "User not found");

                user.RefreshToken = string.Empty;
                user.RefreshTokenExpiry = null;

                await _authRepo.SaveAsync();
                _logger.LogInformation("Logout successful for UserId {UserId}", userId);
                return new Response<object>(200, "Logout successfull.");

            }
            catch (StoredProcedureException ex)
            {
                _logger.LogError(ex, "SP execution failed during password reset.");
                return new Response<object>(500, "Database error occurred. Please try again later.");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Logout failed");

                return new Response<object>(500, ex.Message);
            }
        }

        public async Task<Response<object>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            try
            {
                _logger.LogInformation("Forgot password request for email {Email}", dto.Email);

                var user = await _userDapperRepository.GetByEmailAsync(dto.Email.Trim().ToLower());
                if (user == null)
                {
                    _logger.LogWarning("Forgot password: user not found for email {Email}", dto.Email);
                    return new Response<object>(404, "User not found");
                }

                var tokenBytes = RandomNumberGenerator.GetBytes(48);

                var token = Convert.ToBase64String(tokenBytes)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");


                user.PasswordResetToken = token;
                user.PasswordResetExpiry = DateTime.UtcNow.AddMinutes(15);

                await _authRepo.UpdateAsync(user);

                var frontendUrl = _config["FrontEndUrl:BaseUrl"];

                if (string.IsNullOrWhiteSpace(frontendUrl))
                    throw new Exception("Frontend BaseUrl is not configured");

                var resetLink = $"{frontendUrl}/reset-password?token={token}";


                await _emailService.SendPasswordResetEmailAsync(dto.Email, resetLink);

                _logger.LogInformation("Password reset email sent to {Email}", dto.Email);
                return new Response<object>(200, "Password reset link sent");
            }
            catch (StoredProcedureException ex)
            {
                _logger.LogError(ex, "SP execution failed during password reset.");
                return new Response<object>(500, "Database error occurred. Please try again later.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Forgot password failed");
                return new Response<object>(500, ex.Message);
            }
        }


        public async Task<Response<string>> ResetPasswordAsync(ResetPasswordDto dto, int? userId)
        {
            try
            {
                dto.Token = dto.Token?.Trim();
                dto.CurrentPassword = dto.CurrentPassword?.Trim();
                dto.NewPassword = dto.NewPassword?.Trim();

                // ===================== FORGOT PASSWORD FLOW =====================
                if (!string.IsNullOrWhiteSpace(dto.Token))
                {
                    _logger.LogInformation("Password reset using token");

                    var user = await _userDapperRepository.GetByPasswordResetTokenAsync(dto.Token);

                    if (user == null || user.PasswordResetExpiry < DateTime.UtcNow)
                        return new Response<string>(400, "Invalid or expired reset token.");

                    if (BCrypt.Net.BCrypt.Verify(dto.NewPassword, user.PassWord))
                        return new Response<string>(400, "New password cannot be the same as the old password.");

                    user.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                    user.PasswordResetToken = null;
                    user.PasswordResetExpiry = null;

                    await _authRepo.UpdateAsync(user);

                    _logger.LogInformation("Password reset successful");
                    return new Response<string>(200, "Password reset successful.");
                }

                // ===================== CHANGE PASSWORD FLOW =====================
                _logger.LogInformation("Password change request for UserId {UserId}", userId);

                if (!userId.HasValue)
                    return new Response<string>(401, "Unauthorized.");

                if (string.IsNullOrWhiteSpace(dto.CurrentPassword))
                    return new Response<string>(400, "Current password is required.");

                if (string.IsNullOrWhiteSpace(dto.NewPassword))
                    return new Response<string>(400, "New password is required.");

                var existingUser = await _userDapperRepository.GetByUserIdAsync(userId.Value);

                if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, existingUser.PassWord))
                    return new Response<string>(400, "Invalid current password.");

                if (BCrypt.Net.BCrypt.Verify(dto.NewPassword, existingUser.PassWord))
                    return new Response<string>(400, "New password cannot be the same as the current password.");

                existingUser.PassWord = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                await _authRepo.UpdateAsync(existingUser);

                _logger.LogInformation("Password changed successfully for UserId {UserId}", userId);
                return new Response<string>(200, "Password changed successfully.");
            }
            catch (StoredProcedureException spEx)
            {
                _logger.LogError(spEx, "SP execution failed during password reset.");
                return new Response<string>(500, "Database error occurred. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during password reset.");

                return new Response<string>(
                    500,
                    "An error occurred while processing your request."
                );
            }
        }

    }
}
