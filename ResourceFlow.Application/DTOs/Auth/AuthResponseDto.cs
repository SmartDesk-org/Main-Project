using System.Text.Json.Serialization;

namespace ResourceFlow.Application.DTOs.Auth
{
    public class AuthResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? AccessTokenExpiry { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? RefreshTokenExpiry { get; set; }

        public AuthResponseDto(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public AuthResponseDto(int statusCode, string message, string accessToken, string refreshToken)
        {
            StatusCode = statusCode;
            Message = message;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
