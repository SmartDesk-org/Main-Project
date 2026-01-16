using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities
{
    public  class ClientComplaint:BaseEntity
    {
        public int Id { get; set; }
        
        public int CompanyId { get; set; }
        public string Title  { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public bool IsResolved { get; set; } = false;
    }
}
