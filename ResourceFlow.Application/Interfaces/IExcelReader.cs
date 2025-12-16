using ResourceFlow.Application.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces
{
    public interface IExcelReader
    {
        List<EmployeeImportDto> ReadEmployeeExcel(Stream stream);
    }

}
