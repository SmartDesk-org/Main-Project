using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roles = ResourceFlow.Domain.Entities.Authentication.Roles;


namespace ResourceFlow.Domain.Entities.Authorization
{
    public class RolePermission
    {
        public int RoleId { get; set; }             // FK to Role table
        public int PermissionId { get; set; }       // FK to Permission table

        public Roles Role { get; set; }              // Reference to Role entity
        public Permission Permission { get; set; }  // Reference to Permission entity
    }

}
