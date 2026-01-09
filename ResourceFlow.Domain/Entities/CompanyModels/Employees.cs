using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.CompanyModels
{
    public class Employees:BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int? DefaultFloorId { get; set; }
        public string Department { get; set; }
        public EmployeeStatus Status { get; set; }
        public string? Designation { get; set; } 
        public virtual User User { get; set; } 
        public virtual CompanyDetails Company { get; set; } 

    }
}
