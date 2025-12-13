using ResourceFlow.Domain.Enums;

namespace ResourceFlow.Domain.Entities.Finance
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string PaymentIntentId { get; set; } = default!;
        public string ReceiptId { get; set; } = default!;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = default!;//enum paymentstatus
        public CompanyDetails Company { get; set; } = default!;

    }
}
