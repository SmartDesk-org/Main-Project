using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roles = ResourceFlow.Domain.Entities.Authentication.Roles;


namespace ResourceFlow.Domain.Entities.Authorization
{
    public class RolePermission:BaseEntity
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        public Roles Role { get; set; } 

        public int ModuleId { get; set; }
        public AppModule Module { get; set; } 

        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanView { get; set; }
        public bool CanDelete { get; set; }
    }

}
