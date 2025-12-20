using ResourceFlow.Domain.Enums.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Authorization
{
    public class AppModule:BaseEntity
    {
        public int Id { get; set; }

        // Friendly name for UI (can be dynamic)
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Enum stored as INT in DB for performance and type safety
        [Required]
        public ModuleCode Code { get; set; }

        // Parent module for hierarchy (nullable for top-level modules)
        public int? ParentId { get; set; }
        public AppModule? Parent { get; set; }

        // Navigation property for child modules
        public ICollection<AppModule> Children { get; set; } = new List<AppModule>();


    }
}
