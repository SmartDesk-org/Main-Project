using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Common
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response(int statusCode, string message, object data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
