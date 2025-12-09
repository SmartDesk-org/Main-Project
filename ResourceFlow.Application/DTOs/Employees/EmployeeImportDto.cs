
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Employees
{
    public class EmployeeImportDto
    {
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int? DefaultFloorId { get; set; }
    }

}
