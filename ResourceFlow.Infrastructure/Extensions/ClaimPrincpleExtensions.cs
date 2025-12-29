using System.Diagnostics;
using System.Security.Claims;

namespace ResourceFlow.Infrastructure.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal User)
        {
            var claimsDump = string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
            Debug.WriteLine($"[CLAIMS DEBUG] All Claims: {claimsDump}");

            var userIdClaim = User.FindFirst("userId");

            Debug.WriteLine($"[CLAIMS DEBUG] userId found? {userIdClaim?.Value}");

            if (string.IsNullOrEmpty(userIdClaim?.Value) || !int.TryParse(userIdClaim.Value, out int userId))
            {
                Debug.WriteLine("[CLAIMS ERROR] Missing or invalid userId claim");
                throw new UnauthorizedAccessException("Invalid or missing claim");
            }

            Debug.WriteLine($"[CLAIMS DEBUG] UserId = {userId}");
            return userId;
        }

        public static int GetUserRole(this ClaimsPrincipal User)
        {
            var claimsDump = string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
            Debug.WriteLine($"[CLAIMS DEBUG] All Claims: {claimsDump}");

            var roleClaim = User.FindFirst("roleId");

            Debug.WriteLine($"[CLAIMS DEBUG] roleId found? {roleClaim?.Value}");

            if (string.IsNullOrEmpty(roleClaim?.Value) ||
                !int.TryParse(roleClaim.Value, out int roleId))
            {
                Debug.WriteLine("[CLAIMS ERROR] Missing or invalid roleId claim");
                throw new UnauthorizedAccessException("Invalid or missing claim.");
            }

            Debug.WriteLine($"[CLAIMS DEBUG] RoleId = {roleId}");
            return roleId;
        }


        public static string GetUserEmail(this ClaimsPrincipal User)
        {
            var claimsDump = string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
            Debug.WriteLine($"[CLAIMS DEBUG] All Claims: {claimsDump}");

            var emailClaim = User.FindFirst("UserEmail");

            Debug.WriteLine($"[CLAIMS DEBUG] UserEmail found? {emailClaim?.Value}");

            if (string.IsNullOrEmpty(emailClaim?.Value))
            {
                Debug.WriteLine("[CLAIMS ERROR] Missing or invalid UserEmail claim");
                throw new UnauthorizedAccessException("Invalid or missing claim.");
            }

            Debug.WriteLine($"[CLAIMS DEBUG] UserEmail = {emailClaim.Value}");
            return emailClaim.Value;
        }
    }
}
