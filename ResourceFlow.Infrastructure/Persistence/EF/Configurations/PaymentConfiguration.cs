using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Finance;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.TransactionId)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.PaymentDate)
                   .IsRequired();

            // Relationships
            builder.HasOne(p => p.Company)
                   .WithMany()                 // One company → many payments
                   .HasForeignKey(p => p.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Subscription navigation added later
            // builder.HasOne(p => p.Subscription)
            //        .WithMany()
            //        .HasForeignKey(p => p.SubscriptionId)
            //        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
