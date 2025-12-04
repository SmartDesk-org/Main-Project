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
<<<<<<< HEAD:ResourceFlow.Domain/Entities/Authntication/User.cs
    public class User
=======
    public  class User:BaseEntity
>>>>>>> 15c2d3a39e9e05e69e03384ad7e02cc67d9be65e:ResourceFlow.Domain/Entities/Authentication/User.cs
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

        public Role? Role { get; set; }
    }
}
