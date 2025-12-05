using ResourceFlow.Domain.Entities;

public class CompanyDetails : BaseEntity
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = false;
}
