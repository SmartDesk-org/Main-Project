using ClosedXML.Excel;
using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.DTOs.Employees;

namespace ResourceFlow.Application.Common
{
    public class ExcelReader : IExcelReader
    {
        public List<EmployeeImportDto> ReadEmployeeExcel(Stream stream)
        {
            var list = new List<EmployeeImportDto>();

            using var workbook = new XLWorkbook(stream);
            var sheet = workbook.Worksheet(1);

            foreach (var row in sheet.RowsUsed().Skip(1)) // skip header
            {
                list.Add(new EmployeeImportDto
                {
                    EmployeeName = row.Cell(1).GetString().Trim(),
                    Email = row.Cell(2).GetString().Trim(),
                    Department = row.Cell(3).GetString().Trim(),
                    DefaultFloorId = ParseIntSafe(row.Cell(4))
                });
            }

            return list;
        }

        private int? ParseIntSafe(IXLCell cell)
        {
            var raw = cell.GetString()?.Trim();

            if (string.IsNullOrWhiteSpace(raw))
                return null;

            if (int.TryParse(raw, out var num))
                return num;

            if (cell.DataType == XLDataType.Number && cell.TryGetValue(out double dbl))
                return (int)dbl;

            return null;
        }
    }
}
