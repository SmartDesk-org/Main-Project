using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Domain.Entities.Finance
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int SubscriptionId { get; set; }
        public string TransactionId { get; set; } = default!;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = default!; //enum paymentstatus
        public CompanyDetails Company { get; set; } = default!;

    }
}
