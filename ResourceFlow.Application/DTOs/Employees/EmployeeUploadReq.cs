using Microsoft.AspNetCore.Http;

namespace ResourceFlow.Application.DTOs.Employees
{
    public class EmployeeUploadRequest
{
    public IFormFile File { get; set; }
}

}