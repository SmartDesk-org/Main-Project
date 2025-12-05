using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;

using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Entities.Authentication;

public class CompanyDetails : BaseEntity
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = false;


    public ICollection<Employees> Employees { get; set; } = new List<Employees>();
    public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; } = new List<CompanySubscription>();


    public virtual ICollection<User> Users { get; set; }
}
