namespace ResourceFlow.Application.DTOs.Employees
{
    public class ImportErrorDto
    {
        public int RowNumber { get; set; }
        public string Error { get; set; }

        public ImportErrorDto(int rowNumber, string error)
        {
            RowNumber = rowNumber;
            Error = error;
        }
    }
}
