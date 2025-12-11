using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public  class CompanyFloor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; } = default!;
        public int FloorNumber { get; set; }
        public int CompanyId { get; set; }
        public string Map { get; set; } = default!;

        public CompanyDetails Company { get; set; }

    }
}
