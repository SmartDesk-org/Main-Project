using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceFlow.Application.DTOs.Employees;

namespace ResourceFlow.Application.Validators.Employee
{

    public interface IEmployeeImportValidator
    {
        Task<(List<EmployeeImportDto> valid, List<ImportErrorDto> errors)>
            ValidateAsync(List<EmployeeImportDto> rows, int companyId);
    }

}
