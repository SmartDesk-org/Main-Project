using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ResourceFlow.Domain.Entities.Authentication
{

    public  class User:BaseEntity
    {
        public int UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // hashed password
        public string PassWord { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiry { get; set; }

        // for forgot password flow
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpiry { get; set; }

        public Roles? Role { get; set; }
        public virtual Employees? Employee { get; set; }
    }
}
