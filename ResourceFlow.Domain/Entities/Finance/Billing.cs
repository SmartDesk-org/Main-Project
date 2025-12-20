using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Enums;

public class Billing : BaseEntity
{
    public int BillingId { get; set; }

    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyMail { get; set; }
    public int SubscriptionId { get; set; }
    public string? SubscriptionName { get; set; }
    public int CompanySubscriptionId { get; set; }

    public string InvoiceNumber { get; set; }

    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }

    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public DateTime BillingDate { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }

    public string? InvoicePdfPath { get; set; }

    public CompanyDetails Company { get; set; }
}

