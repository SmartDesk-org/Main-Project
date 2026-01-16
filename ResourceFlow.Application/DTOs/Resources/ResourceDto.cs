using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Resources
{
    public  class ResourceDto
    {
        public int Id { get; set; }
        public int ResourceTypeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; }
        public bool IsAvailable { get; set; }
        public string MetadataJson { get; set; } = "{}";
    }
}
