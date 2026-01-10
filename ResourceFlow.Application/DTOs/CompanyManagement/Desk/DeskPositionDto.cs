using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Desk
{
    public class DeskPositionDto
    {
        public int DeskId { get; set; }

      
        public float XPosition { get; set; }
        public float YPosition { get; set; }
    }
}
