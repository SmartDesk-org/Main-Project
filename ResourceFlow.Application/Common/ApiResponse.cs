using System.Text.Json.Serialization;
namespace ResourceFlow.Application.Common{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int statusCode, string? message = null, T? data = default)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }
        // ✅ Static helper methods for controller convenience
        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>(200, message, data);
        }

        public static ApiResponse<T> Created(T data, string message = "Created successfully")
        {
            return new ApiResponse<T>(201, message, data);
        }

        public static ApiResponse<T> Error(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(statusCode, message);
        }
    }
}
