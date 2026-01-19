public class EmployeeGetAllDto
{
    public int EmployeeId { get; set; }
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public int DefaultFloorId { get; set; }
    public string? Department { get; set; }
    public string? Status { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public int RoleId { get; set; }
    public bool IsActive { get; set; }
    public bool IsBlocked { get; set; }
    public int FailedLoginAttempts { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int? ModifiedBy { get; set; }
}
