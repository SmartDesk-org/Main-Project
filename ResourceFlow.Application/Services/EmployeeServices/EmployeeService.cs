using Microsoft.AspNetCore.Http;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Application.Validators.Employee;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.FloorModels;
using ResourceFlow.Domain.Enums;
using OfficeOpenXml;

using System.Collections.Concurrent;

public class EmployeeService : IEmployeeService
{
    private readonly IGenericRepository<User> _userRepo;
    private readonly IGenericRepository<Employees> _employeeRepo;
    private readonly IGenericRepository<Floors> _floorRepo;
    private readonly IExcelReader _excelReader;
    private readonly IEmployeeImportValidator _validator;
    private readonly IUnitOfWork _uow;
    private readonly IEmployeeEmailService _emailService;

    public EmployeeService(
        IGenericRepository<User> userRepo,
        IGenericRepository<Employees> employeeRepo,
        IGenericRepository<Floors> floorRepo,
        IExcelReader excelReader,
        IEmployeeImportValidator validator,
        IUnitOfWork uow,
        IEmployeeEmailService employeeEmailService
    )
    {
        _userRepo = userRepo;
        _employeeRepo = employeeRepo;
        _floorRepo = floorRepo;
        _excelReader = excelReader;
        _validator = validator;
        _uow = uow;
        _emailService = employeeEmailService;
    }

    public async Task<ApiResponse<BulkUploadResponse>> BulkUploadAsync(IFormFile file)
    {
        var response = new BulkUploadResponse();

        // --- VALIDATION & READING START ---
        if (file == null || file.Length == 0)
        {
            return new ApiResponse<BulkUploadResponse>(400, "Invalid file length");
        }

        using var stream = file.OpenReadStream();
        var rows = _excelReader.ReadEmployeeExcel(stream);

        response.TotalRecords = rows.Count;
        int companyId = 5; // TODO: make dynamic later
        var (validRows, errors) = await _validator.ValidateAsync(rows, companyId);

        response.Errors = errors;
        response.FailedRecords = errors.Count;

        if (!validRows.Any())
        {
            return new ApiResponse<BulkUploadResponse>(
                statusCode: 400,
                message: "All rows failed validation. Please review the errors.",
                data: new BulkUploadResponse
                {
                    TotalRecords = rows.Count,
                    SuccessfulRecords = 0,
                    FailedRecords = errors.Count,
                    Errors = errors,
                    ChunkSize = 0,
                    TotalChunks = 0
                }
            );
        }

        int chunkSize = 200;
        var chunks = validRows
            .Select((row, index) => new { row, index })
            .GroupBy(x => x.index / chunkSize)
            .Select(g => g.Select(x => x.row).ToList())
            .ToList();

        response.ChunkSize = chunkSize;
        response.TotalChunks = chunks.Count;

        foreach (var chunk in chunks)
        {
            await _uow.BeginTransactionAsync();
            bool transactionCommitted = false;

            var newUsers = new List<User>();
            var passwordMap = new Dictionary<string, string>();

            try
            {
                foreach (var r in chunk)
                {
                    var rawPassword = "Emp@" + Guid.NewGuid().ToString("N")[..6];
                    passwordMap[r.Email] = rawPassword;

                    newUsers.Add(new User
                    {
                        UserName = r.Email,
                        Email = r.Email,
                        PassWord = BCrypt.Net.BCrypt.HashPassword(rawPassword),
                        CompanyId = companyId,
                        RoleId = 2,
                        IsActive = true,
                        IsBlocked = false
                    });
                }

                await _userRepo.AddRangeAsync(newUsers);
                await _uow.SaveChangesAsync();

                var newEmployees = new List<Employees>();

                for (int i = 0; i < newUsers.Count; i++)
                {
                    newEmployees.Add(new Employees
                    {
                        UserId = newUsers[i].UserId,
                        CompanyId = companyId,
                        Department = chunk[i].Department,
                        DefaultFloorId = chunk[i].DefaultFloorId,
                        Status = EmployeeStatus.Active
                    });
                }

                await _employeeRepo.AddRangeAsync(newEmployees);
                await _uow.SaveChangesAsync();


                await _uow.CommitAsync();
                transactionCommitted = true;
            }
            catch (Exception ex)
            {

                if (!transactionCommitted)
                {
                    await _uow.RollbackAsync();
                }

                return new ApiResponse<BulkUploadResponse>(
                    500,
                    $"Database Import failed: {ex.InnerException?.Message ?? ex.Message}"
                );
            }

            // --- STEP 2: SEND EMAILS (PARALLEL PROCESSING) ---
            if (transactionCommitted)
            {
                // We limit to 8 parallel emails to avoid getting blocked by Gmail for spamming
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 8 };

                await Parallel.ForEachAsync(newUsers, parallelOptions, async (user, token) =>
                {
                    try
                    {
                        var rawPassword = passwordMap[user.Email];
                        var html = EmployeeEmailTemplates.BuildWelcomeEmail(user.Email, rawPassword);

                        await _emailService.SendAsync(
                            to: user.Email,
                            subject: "Welcome to SmartDesk - Your Login Credentials",
                            html: html 
                        );
                    }
                    catch (Exception emailEx)
                    {
                        Console.WriteLine($"Failed to send email to {user.Email}: {emailEx.Message}");
                    }
                });
            }
        }

        response.SuccessfulRecords = validRows.Count;
        return new ApiResponse<BulkUploadResponse>(200, "File uploaded successfully. Emails sent.", response);
    }
    public byte[] GenerateEmployeeUploadTemplate()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Employees");

        // STRICT headers
        sheet.Cells[1, 1].Value = "EmployeeName";
        sheet.Cells[1, 2].Value = "Email";
        sheet.Cells[1, 3].Value = "Department";
        sheet.Cells[1, 4].Value = "DefaultFloorId";

        // Sample row
        sheet.Cells[2, 1].Value = "John Doe";
        sheet.Cells[2, 2].Value = "john@company.com";
        sheet.Cells[2, 3].Value = "IT";
        sheet.Cells[2, 4].Value = 1;

        sheet.Cells[1, 1, 1, 4].Style.Font.Bold = true;
        sheet.Cells.AutoFitColumns();

        return package.GetAsByteArray();
    }
}