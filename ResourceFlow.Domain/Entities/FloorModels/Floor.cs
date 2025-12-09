using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.FloorModels
{
    public class Floors
    {
        public int FloorId { get; set; }
        public int CompanyId { get; set; }
        public string FloorName { get; set; }
        public int FloorNumber { get; set; }
        public string LayoutJson { get; set; }
    }

}
