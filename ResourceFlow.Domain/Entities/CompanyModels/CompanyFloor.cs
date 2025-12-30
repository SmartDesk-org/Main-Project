using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class CompanyFloor : BaseEntity
    {
        public int FloorId { get; set; }
        public int CompanyId { get; set; }
        public string FloorName { get; set; } = default!;
        public int FloorNumber { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Scale { get; set; } = 1;

        public bool IsActive { get; set; } = true;
        public CompanyDetails Company { get; set; } = null!;

        public ICollection<Resource> Resources  {get;set;}


    }
}
