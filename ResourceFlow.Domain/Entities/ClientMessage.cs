using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities
{
    public class ClientMessage:BaseEntity
    {
        public int Id {get;set;}
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;
        public bool IsImportant { get; set; } = false;
    }
}
