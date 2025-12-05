using System.ComponentModel.DataAnnotations;

namespace ResourceFlow.Domain.Entities.Authentication
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiry { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpiry { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public Role? Role { get; set; }
        public CompanyDetails? Company { get; set; }
    }
}
