using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal User)
        {
            var userIdClaim = User.FindFirst("userId");
            if (string.IsNullOrEmpty(userIdClaim?.Value) || !int.TryParse(userIdClaim?.Value, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing claim");
            }
            return userId;
        }
        public static string GetUserRole(this ClaimsPrincipal User)
        {
            var UserRole = User.FindFirst("userRole");
            if (string.IsNullOrEmpty(UserRole?.Value))
            {

                throw new UnauthorizedAccessException("Invalid or missing claim.");

            }
            return UserRole.Value;

        }
        public static string GetUserEmail(this ClaimsPrincipal User)
        {
            var UserEmail = User.FindFirst("UserEmail");
            if (string.IsNullOrEmpty(UserEmail?.Value))
            {
                throw new UnauthorizedAccessException(" Invalid or missing claim.");
            }
            return UserEmail.Value;
        }
    }
}