using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.Authentication
{
    public class Roles : BaseEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
