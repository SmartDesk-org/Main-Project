using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Floors
{
    public class FloorDto
    {
        public int Id { get; set; }
        public string FloorName { get; set; } = null!;
        public int FloorNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Scale { get; set; }
    }
}
