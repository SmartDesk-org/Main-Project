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

        public static string GetUserRole(this ClaimsPrincipal User)
        {
            var claimsDump = string.Join(", ", User.Claims.Select(c => $"{c.Type}={c.Value}"));
            Debug.WriteLine($"[CLAIMS DEBUG] All Claims: {claimsDump}");

            var roleClaim = User.FindFirst("userRole");

            Debug.WriteLine($"[CLAIMS DEBUG] userRole found? {roleClaim?.Value}");

            if (string.IsNullOrEmpty(roleClaim?.Value))
            {
                Debug.WriteLine("[CLAIMS ERROR] Missing or invalid userRole claim");
                throw new UnauthorizedAccessException("Invalid or missing claim.");
            }

            Debug.WriteLine($"[CLAIMS DEBUG] UserRole = {roleClaim.Value}");
            return roleClaim.Value;
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
