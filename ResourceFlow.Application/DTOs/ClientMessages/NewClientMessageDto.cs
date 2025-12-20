using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.ClientMessages
{
    public class NewClientMessageDto
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

       
    }
}
