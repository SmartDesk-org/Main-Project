using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Enums;
using ResourceFlow.Domain.Enums.Authorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Roles = ResourceFlow.Domain.Entities.Authentication.Roles;



namespace ResourceFlow.Domain.Entities.Authorization
{
    public class RolePermission:BaseEntity
    {

        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public ModuleCode ModuleCode { get; set; }

        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }

}
