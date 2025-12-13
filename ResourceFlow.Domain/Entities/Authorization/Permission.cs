using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Authorization
{
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        public int ModuleId { get; set; }

        [Required, MaxLength(50)]
        public string Action { get; set; }

        public AppModule Module { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
