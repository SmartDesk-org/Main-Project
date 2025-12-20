using ResourceFlow.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ResourceFlow.Application.DTOs.Employees
{
    public class UpdateEmployeeDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string Department { get; set; } = string.Empty;

        public int? DefaultFloorId { get; set; }

        [Required]
        public EmployeeStatus Status { get; set; }
    }
}
