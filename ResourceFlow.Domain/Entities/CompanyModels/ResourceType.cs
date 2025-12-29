using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public  class ResourceType:BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty; 
        public string Icon { get; set; } = string.Empty;

        public int DefaultWidth { get; set; }
        public int DefaultHeight { get; set; }

        public bool IsActive { get; set; } = true;


        public ICollection<Resource> Resources { get; set; }
    }
}
