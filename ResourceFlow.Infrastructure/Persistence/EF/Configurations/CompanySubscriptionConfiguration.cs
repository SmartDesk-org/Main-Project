using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class CompanySubscriptionConfiguration:IEntityTypeConfiguration<CompanySubscription>
    {
        public void Configure(EntityTypeBuilder<CompanySubscription> builder)
        {
            builder.ToTable("CompanySubscription");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.Property(c => c.IsActive)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasConversion<int>();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_CompanySubscription_ValidDates",
                    "\"EndDate\" > \"StartDate\""
                );
            });



            builder.HasOne(c => c.Company)
                .WithMany(c => c.CompanySubscriptions)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Subscription)
                .WithMany(s => s.CompanySubscriptions)
                .HasForeignKey(c => c.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
