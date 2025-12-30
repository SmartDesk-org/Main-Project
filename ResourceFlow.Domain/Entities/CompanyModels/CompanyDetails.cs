using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;

using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;

public class CompanyDetails : BaseEntity
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = false;


    public int CompanySubscriptionId { get; set; }
    public ICollection<Employees> Employees { get; set; } = new List<Employees>();
    public virtual CompanySubscription CompanySubscription { get; set; }
    public virtual ICollection<Resource> Resources { get; set; }
    public virtual ICollection<User> Users { get; set; }

    public ICollection<CompanyFloor> CompanyFloors { get; set; } = new List<CompanyFloor>();
   

}
