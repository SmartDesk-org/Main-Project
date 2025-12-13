using ResourceFlow.Domain.Entities;

public class Billing:BaseEntity
{
    public int BillingId { get; set; }
    public int CompanyId { get; set; }
    public int SubscriptionId { get; set; }
    public int CompanySubscriptionId { get; set; }

    public string InvoiceNumber { get; set; }
    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } // Pending, Paid, Failed, Refunded
    public string PaymentMethod { get; set; } // Card, UPI, Bank, Paypal

    public string? TransactionId { get; set; }

    public DateTime BillingDate { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }

    public CompanyDetails Company { get; set; }

}
