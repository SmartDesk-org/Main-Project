using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace ResourceFlow.Application.DTOs.Auth
{
    public class ResetPasswordDto
    {
        public string Token { get; set; } = string.Empty;
        public string CurrentPassword { get; set; }= string.Empty;
        public string NewPassword { get; set; } = null!;
    }
}
