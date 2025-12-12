using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Common
{
    public class Response<Object>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public object? Data { get; set; }

        public Response(int statusCode, string message,string accesstoken ,string refreshtoken)
        {
            StatusCode = statusCode;
            Message = message;
            AccessToken= accesstoken;
            RefreshToken = refreshtoken;
        }
        public Response(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public Response(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
           
        }
        
    }
}
