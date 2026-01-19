using Microsoft.AspNetCore.Http;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Application.Validators.Employee;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
using OfficeOpenXml;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using OfficeOpenXml.Style;
using System.Drawing;
using OfficeOpenXml.DataValidation;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeDapperRepository _dapperRepo;
    private readonly IGenericRepository<User> _userRepo;
    private readonly IGenericRepository<Employees> _employeeRepo;
    private readonly IGenericRepository<CompanyDetails> _companyRepo;
    private readonly IGenericRepository<Subscription> _subscriptionRepo;
    private readonly IGenericRepository<CompanyFloor> _floorRepo;
    private readonly IExcelReader _excelReader;
    private readonly IEmployeeImportValidator _validator;
    private readonly ICompanyDapperRepository _DapperCompanyRepo;
    private readonly IUnitOfWork _uow;
    private readonly IEmployeeDapperRepository _employeeDapperRepository;

    // CRITICAL CHANGE: Use ScopeFactory (Singleton) instead of ServiceProvider (Request-Scoped)
    private readonly IServiceScopeFactory _scopeFactory;

    public EmployeeService(
        IEmployeeDapperRepository dapperRepo,
        IGenericRepository<User> userRepo,
        IGenericRepository<Employees> employeeRepo,
        IGenericRepository<CompanyDetails> companyRepo,
        IGenericRepository<Subscription> subscriptionRepo,
        IGenericRepository<CompanyFloor> companyFloor,
        IExcelReader excelReader,
        IEmployeeImportValidator validator,
        IUnitOfWork uow,
        IServiceScopeFactory scopeFactory,
        ICompanyDapperRepository dapperRepository,
        IEmployeeDapperRepository employeeDapperRepository)
    {
        _floorRepo = companyFloor;
        _dapperRepo = dapperRepo;
        _userRepo = userRepo;
        _employeeRepo = employeeRepo;
        _companyRepo = companyRepo;
        _subscriptionRepo = subscriptionRepo;
        _excelReader = excelReader;
        _validator = validator;
        _uow = uow;
        _scopeFactory = scopeFactory;
        _DapperCompanyRepo = dapperRepository;

        _employeeDapperRepository = employeeDapperRepository;

    }

    public async Task<ApiResponse<BulkUploadResponse>> BulkUploadAsync(IFormFile file, int companyId)
    {
        var response = new BulkUploadResponse();

        // 1. Basic Validation
        if (file == null || file.Length == 0)
            return new ApiResponse<BulkUploadResponse>(400, "Invalid file length");

        using var stream = file.OpenReadStream();
        var rows = _excelReader.ReadEmployeeExcel(stream);

        if (!rows.Any())
            return new ApiResponse<BulkUploadResponse>(400, "File is empty.");

        response.TotalRecords = rows.Count;

        // 2. Validate Rows
        var (validRows, errors) = await _validator.ValidateAsync(rows, companyId);
        response.Errors = errors;
        response.FailedRecords = errors.Count;

        if (!validRows.Any())
        {
            response.SuccessfulRecords = 0;
            return new ApiResponse<BulkUploadResponse>(
                400,
                "No new employees added. All rows already exist.",
                response
            );
        }


        // 3. Subscription Check
        var company = await _companyRepo.GetByIdAsync(companyId);
        if (company == null)
        {
            return new ApiResponse<BulkUploadResponse>(404, "Company not found");
        }

        var companySubscription =
            await _DapperCompanyRepo.GetActiveCompanySubscriptionByCompanyId(companyId);

        if (companySubscription == null)
        {
            return new ApiResponse<BulkUploadResponse>(
                400, "No active subscription for this company"
            );
        }

        var subscription =
            await _subscriptionRepo.GetByIdAsync(companySubscription.SubscriptionId);

        if (subscription == null)
        {
            return new ApiResponse<BulkUploadResponse>(
                404, "Subscription plan not found"
            );
        }


        var existingEmployees = await _dapperRepo.GetEmployeeByCompanyId(companyId);
        int currentCount = existingEmployees.Count(e => e.Status != EmployeeStatus.Terminated);

        if (currentCount + validRows.Count > subscription.MaxEmployees)
        {
            return new ApiResponse<BulkUploadResponse>(400,
                $"Limit Exceeded. Plan allows {subscription.MaxEmployees}. You have {currentCount}.");
        }

        int chunkSize = 50;
        var chunks = validRows.Chunk(chunkSize).ToList();

        response.ChunkSize = chunkSize;
        response.TotalChunks = chunks.Count;

        var usersToSendEmailsTo = new List<User>();
        var passwordMap = new Dictionary<string, string>();
        await _uow.BeginTransactionAsync();
        try
        {
            foreach (var chunk in chunks)
            {
                var newUsers = new List<User>();
                var newEmployees = new List<Employees>();

                foreach (var r in chunk)
                {
                    var rawPassword = "Emp@" + Guid.NewGuid().ToString("N")[..6];
                    passwordMap[r.Email] = rawPassword;

                    newUsers.Add(new User
                    {
                        UserName = r.EmployeeName,
                        Email = r.Email,
                        PassWord = BCrypt.Net.BCrypt.HashPassword(rawPassword),
                        CompanyId = companyId,
                        RoleId = 2,
                        IsActive = true,
                        IsBlocked = false,

                    });
                }

                await _userRepo.AddRangeAsync(newUsers);
                await _uow.SaveChangesAsync(); 

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

                usersToSendEmailsTo.AddRange(newUsers);
            }

            await _uow.CommitAsync();
        }
        catch (Exception ex)
        {
            await _uow.RollbackAsync();
            return new ApiResponse<BulkUploadResponse>(500, $"DB Error: {ex.Message}");
            
        }
        _ = ProcessEmailBackground(usersToSendEmailsTo, passwordMap);

        response.SuccessfulRecords = validRows.Count;
        return new ApiResponse<BulkUploadResponse>(200, "Upload successful. Emails are being sent.", response);
    }


    private async Task ProcessEmailBackground(List<User> users, Dictionary<string, string> passwordMap)
    {

        var successfulUserIds = new ConcurrentBag<int>();
        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 8 };
        Console.WriteLine($" Starting email sending for {users.Count} users...");

        await Parallel.ForEachAsync(users, parallelOptions, async (user, token) =>
        {
            using var scope = _scopeFactory.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmployeeEmailService>();

            try
            {
                var rawPassword = passwordMap[user.Email];
                var html = EmployeeEmailTemplates.BuildWelcomeEmail(user.Email, rawPassword);
                await emailService.SendAsync(user.Email, "Welcome to SmartDesk", html);

                successfulUserIds.Add(user.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed {user.Email}: {ex.Message}");
            }
        });
        if (!successfulUserIds.IsEmpty)
        {
            using var scope = _scopeFactory.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var userRepo = scope.ServiceProvider.GetRequiredService<IGenericRepository<User>>();
            foreach (var userId in successfulUserIds)
            {
                var user = await userRepo.GetByIdAsync(userId);
                if (user != null)
                {
                    userRepo.Update(user);
                }
            }

            await uow.SaveChangesAsync();
            Console.WriteLine($"✅ Bulk updated status for {successfulUserIds.Count} users.");
        }
    }

    public byte[] GenerateEmployeeUploadTemplate()
    {
        // Set License Context
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Employees");

        // =====================================================
        // 1. HEADERS & STYLING
        // =====================================================
        sheet.Cells[1, 1].Value = "EmployeeName";
        sheet.Cells[1, 2].Value = "Email";
        sheet.Cells[1, 3].Value = "Department";
        sheet.Cells[1, 4].Value = "DefaultFloorId";

        // Style the headers
        using (var headerRange = sheet.Cells[1, 1, 1, 4])
        {
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
            headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }
        sheet.Cells["A2:D1000"].Style.Locked = false;

        sheet.Cells[2, 1].Value = "John Doe";
        sheet.Cells[2, 2].Value = "john@company.com";
        sheet.Cells[2, 3].Value = "IT"; // Must match a dropdown value
        sheet.Cells[2, 4].Value = 1;

        // =====================================================
        // 4. DEPARTMENT DROPDOWN (Strict Validation)
        // =====================================================
        var departments = new[]
        {
        "IT", "HR", "Finance", "Sales", "Marketing", "Operations"
    };

        // Add validation to Column C (Rows 2 to 1000)
        var departmentValidation = sheet.DataValidations.AddListValidation("C2:C1000");

        foreach (var dept in departments)
        {
            departmentValidation.Formula.Values.Add(dept);
        }

        // STRICT ENFORCEMENT
        departmentValidation.ShowErrorMessage = true;
        // 'Stop' prevents the user from typing anything that isn't in the list
        departmentValidation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
        departmentValidation.ErrorTitle = "Invalid Selection";
        departmentValidation.Error = "You must select a Department from the dropdown list.";

        departmentValidation.ShowInputMessage = true;
        departmentValidation.PromptTitle = "Select Department";
        departmentValidation.Prompt = "Please select from the list.";

        // =====================================================
        // 5. PROTECT SHEET
        // =====================================================
        sheet.Cells.AutoFitColumns();

        // Enable protection
        sheet.Protection.IsProtected = true;

        // Allow users to click on the editable cells (A2:D1000)
        sheet.Protection.AllowSelectUnlockedCells = true;

        // Prevent users from clicking/selecting the headers (Row 1)
        sheet.Protection.AllowSelectLockedCells = false;

        return package.GetAsByteArray();
    }

    public async Task<ApiResponse<object>> CreateEmployeeAsync(EmployeeImportDto dto, int companyId)
    {
        if (dto == null)
            return new ApiResponse<object>(400, "Invalid request");

        dto.EmployeeName = dto.EmployeeName?.Trim();
        dto.Email = dto.Email?.Trim().ToLower();
        dto.Department = dto.Department?.Trim();

        // 1️⃣ Basic + bulk-style validation
        var (validRows, errors) =
            await _validator.ValidateAsync(new List<EmployeeImportDto> { dto }, companyId);

        if (errors.Any())
            return new ApiResponse<object>(400, "Validation failed", errors);

        // 2️⃣ Company check
        var company = await _companyRepo.GetByIdAsync(companyId);
        if (company == null)
            return new ApiResponse<object>(404, "Company not found");

        // 3️⃣ ✅ FLOOR BELONGS TO COMPANY CHECK (CRITICAL FIX)
        var floorExists = await _floorRepo.FindAsync(f =>
            f.FloorId == dto.DefaultFloorId &&
            f.CompanyId == companyId &&
            !f.IsDeleted);

        if (!floorExists.Any())
        {
            return new ApiResponse<object>(
                400,
                "Invalid floor. Floor does not belong to this company."
            );
        }

        // 4️⃣ Subscription check
        var companySubscription =
            await _DapperCompanyRepo.GetActiveCompanySubscriptionByCompanyId(companyId);

        if (companySubscription == null)
            return new ApiResponse<object>(400, "No active subscription for this company");

        var subscription =
            await _subscriptionRepo.GetByIdAsync(companySubscription.SubscriptionId);

        if (subscription == null)
            return new ApiResponse<object>(404, "Subscription plan not found");

        var existingEmployees = await _dapperRepo.GetEmployeeByCompanyId(companyId);
        int currentCount = existingEmployees.Count(e => e.Status != EmployeeStatus.Terminated);

        if (currentCount + 1 > subscription.MaxEmployees)
            return new ApiResponse<object>(
                400,
                $"Limit exceeded. Plan allows {subscription.MaxEmployees} employees."
            );

        var rawPassword = "Emp@" + Guid.NewGuid().ToString("N")[..6];

        await _uow.BeginTransactionAsync();
        try
        {
            var user = new User
            {
                UserName = dto.EmployeeName,
                Email = dto.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(rawPassword),
                CompanyId = companyId,
                RoleId = 2,
                IsActive = true,
                IsBlocked = false
            };

            await _userRepo.AddAsync(user);
            await _uow.SaveChangesAsync();

            var employee = new Employees
            {
                UserId = user.UserId,
                CompanyId = companyId,
                Department = dto.Department,
                DefaultFloorId = dto.DefaultFloorId,
                Status = EmployeeStatus.Active
            };

            await _employeeRepo.AddAsync(employee);
            await _uow.SaveChangesAsync();

            await _uow.CommitAsync();

            _ = ProcessEmailBackground(
                new List<User> { user },
                new Dictionary<string, string> { { user.Email, rawPassword } }
            );

            return new ApiResponse<object>(200, "Employee created successfully");
        }
        catch
        {
            await _uow.RollbackAsync();
            throw;
        }
    }


    public async Task<Response<IEnumerable<EmployeeGetAllDto>>> GetAllEmployees()
    {
        var result = await _employeeDapperRepository.GetAllEmployeesAsync();
        if (result == null || !result.Any())
        {
            return new Response<IEnumerable<EmployeeGetAllDto>>(404, "Employees Not Found");
        }
        return new Response<IEnumerable<EmployeeGetAllDto>>(200, "Employees Fetched Successully", result);
    }
    public async Task<ApiResponse<object>> UpdateEmployeeAsync(
    int employeeId,
    UpdateEmployeeDto dto,
    int companyId)
    {
        var employee = await _employeeRepo.FindAsync(e =>
            e.Id == employeeId &&
            e.CompanyId == companyId &&
            !e.IsDeleted);

        var entity = employee.FirstOrDefault();

        if (entity == null)
            return new ApiResponse<object>(404, "Employee not found");

        // ✅ FLOOR BELONGS TO COMPANY CHECK
        var floorExists = await _floorRepo.FindAsync(f =>
            f.FloorId == dto.DefaultFloorId &&
            f.CompanyId == companyId &&
            !f.IsDeleted);

        if (!floorExists.Any())
        {
            return new ApiResponse<object>(
                400,
                "Invalid floor. Floor does not belong to this company."
            );
        }

        entity.Department = dto.Department?.Trim();
        entity.DefaultFloorId = dto.DefaultFloorId;
        entity.Status = dto.Status;
        entity.ModifiedAt = DateTime.UtcNow;

        await _employeeRepo.UpdateAsync(entity);

        return new ApiResponse<object>(200, "Employee updated successfully");
    }

    public async Task<ApiResponse<object>> DeleteEmployeeAsync(
        int employeeId,
        int companyId)
    {
        var employee = await _employeeRepo
            .FindAsync(e =>
                e.Id == employeeId &&
                e.CompanyId == companyId &&
                !e.IsDeleted);

        var entity = employee.FirstOrDefault();

        if (entity == null)
            return new ApiResponse<object>(404, "Employee not found");

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;

        await _employeeRepo.UpdateAsync(entity);

        return new ApiResponse<object>(200, "Employee deleted successfully");
    }

}