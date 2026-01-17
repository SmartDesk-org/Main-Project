using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{

    public class Resource:BaseEntity
    {

        public int Id { get; set; }
        public string ResourceName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int FloorId { get; set; }
        public int ResourceTypeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rotation { get; set; } = 0;
        public string MetadataJson { get; set; } = "{}";


        public bool IsAvailable { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public string QRCodeValue { get; set; } = null!;       // Unique identifier
        public string QRCodeImage { get; set; } = null!;       // Optional Base64 image
        public CompanyDetails Company { get; set; } = null!;
        public CompanyFloor Floor { get; set; } = null!;
        public ResourceType ResourceType { get; set; } = null!;

    }
}
