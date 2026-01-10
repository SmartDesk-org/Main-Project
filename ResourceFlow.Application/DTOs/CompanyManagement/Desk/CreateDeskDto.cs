using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.CompanyManagement.Desk
{
    public class CreateDeskDto
    {
        public int CompanyId { get; set; }
        public int FloorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public JsonElement? SpecificationsJson { get; set; }
    }
}
