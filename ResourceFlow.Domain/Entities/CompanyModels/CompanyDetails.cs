using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;

using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.SubscriptionModels;

namespace ResourceFlow.Domain.Entities.CompanyModels 
{ 
public class CompanyDetails : BaseEntity
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public bool IsActive { get; set; } = false;

    // Navigation properties
    public virtual ICollection<CompanyFloor> CompanyFloors { get; set; } = new List<CompanyFloor>();
    public virtual ICollection<CompanyDesk> Desks { get; set; } = new List<CompanyDesk>();
    public virtual ICollection<CompanyMeetingRoom> MeetingRooms { get; set; } = new List<CompanyMeetingRoom>();

    // Existing navigation properties
    public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
    public virtual ICollection<CompanySubscription> CompanySubscriptions { get; set; } = new List<CompanySubscription>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
}