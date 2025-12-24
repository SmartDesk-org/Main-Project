using ResourceFlow.Domain.Entities.CompanyModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResourceFlow.Domain.Enums;
namespace ResourceFlow.Domain.Entities.Authentication
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? RefreshTokenExpiry { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpiry { get; set; }
        public Roles? Role { get; set; }
        public virtual Employees? Employee { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public CompanyDetails? Company { get; set; }
        [NotMapped]
        public RoleEnum RoleEnum
        {
            get => (RoleEnum)RoleId;
            set => RoleId = (int)value;
        }
    }
}
