using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities;

public class BillingConfiguration : IEntityTypeConfiguration<Billing>
{
    public void Configure(EntityTypeBuilder<Billing> builder)
    {
        // TABLE
        builder.ToTable("Billing");

        // PRIMARY KEY
        builder.HasKey(b => b.BillingId);

        // PROPERTIES
        builder.Property(b => b.InvoiceNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(b => b.PaymentStatus)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.PaymentMethod)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(b => b.BillingDate)
            .IsRequired();

        builder.Property(b => b.SubscriptionStartDate)
            .IsRequired();

        builder.Property(b => b.SubscriptionEndDate)
            .IsRequired();

        builder.Property(b => b.TransactionId)
            .HasMaxLength(200)
            .IsRequired(false);

        // RELATIONSHIP: Company (active)
        builder.HasOne(b => b.Company)
            .WithMany()
            .HasForeignKey(b => b.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // FUTURE RELATIONSHIPS — uncomment when models added
        /*
        builder.HasOne(b => b.Subscription)
            .WithMany()
            .HasForeignKey(b => b.SubscriptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.CompanySubscription)
            .WithMany()
            .HasForeignKey(b => b.CompanySubscriptionId)
            .OnDelete(DeleteBehavior.Restrict);
        */
    }
}
