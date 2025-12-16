using ResourceFlow.Application.DTOs.Employees;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Validators.Employee;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.FloorModels;

public class EmployeeImportValidator : IEmployeeImportValidator
{
    private readonly IGenericRepository<Floors> _floorRepo;
    private readonly IGenericRepository<User> _userRepo;

    public EmployeeImportValidator(
        IGenericRepository<Floors> floorRepo,
        IGenericRepository<User> userRepo
    )
    {
        _floorRepo = floorRepo;
        _userRepo = userRepo;
    }

    public async Task<(List<EmployeeImportDto> valid, List<ImportErrorDto> errors)>
        ValidateAsync(List<EmployeeImportDto> rows, int companyId)
    {
        var errors = new List<ImportErrorDto>();
        var valid = new List<EmployeeImportDto>();

        // ---------------------------------------
        // STEP 1 — Fetch ONLY required floors
        // ---------------------------------------
        var distinctFloorIds = rows
            .Where(r => r.DefaultFloorId != null)
            .Select(r => r.DefaultFloorId.Value)
            .Distinct()
            .ToList();

        var validFloors = await _floorRepo.FindAsync(
            f => f.CompanyId == companyId && distinctFloorIds.Contains(f.FloorId)
        );

        var validFloorIds = validFloors.Select(f => f.FloorId).ToHashSet();


        // ---------------------------------------
        // STEP 2 — Fetch ONLY emails relevant to Excel rows
        // ---------------------------------------
        var distinctEmails = rows
            .Select(r => r.Email.ToLower())
            .Distinct()
            .ToList();

        var existingUsers = await _userRepo.FindAsync(
            u => distinctEmails.Contains(u.Email.ToLower())
        );

        var existingEmails = existingUsers
            .Select(u => u.Email.ToLower())
            .ToHashSet();


        // ---------------------------------------
        // STEP 3 — Detect duplicates inside Excel
        // ---------------------------------------
        var duplicateCounts = rows
            .GroupBy(r => r.Email.ToLower())
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToHashSet();


        // ---------------------------------------
        // STEP 4 — Validate row-by-row
        // ---------------------------------------
        int rowNumber = 2;

        foreach (var r in rows)
        {
            bool hasError = false;
            string email = r.Email.ToLower();

            if (string.IsNullOrWhiteSpace(r.EmployeeName))
            {
                errors.Add(new ImportErrorDto(rowNumber, "EmployeeName required"));
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(r.Email) || !r.Email.Contains("@"))
            {
                errors.Add(new ImportErrorDto(rowNumber, "Invalid Email"));
                hasError = true;
            }

            if (duplicateCounts.Contains(email))
            {
                errors.Add(new ImportErrorDto(rowNumber, "Duplicate Email in Excel"));
                hasError = true;
            }

            if (existingEmails.Contains(email))
            {
                errors.Add(new ImportErrorDto(rowNumber, "Email already exists"));
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(r.Department))
            {
                errors.Add(new ImportErrorDto(rowNumber, "Department required"));
                hasError = true;
            }

            if (r.DefaultFloorId != null && !validFloorIds.Contains(r.DefaultFloorId.Value))
            {
                errors.Add(new ImportErrorDto(rowNumber, "Invalid DefaultFloorId"));
                hasError = true;
            }

            if (!hasError)
                valid.Add(r);

            rowNumber++;
        }

        return (valid, errors);
    }
}
