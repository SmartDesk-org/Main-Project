using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;

public class CompanyDetails : BaseEntity
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public virtual ICollection<User> Users { get; set; }
}
