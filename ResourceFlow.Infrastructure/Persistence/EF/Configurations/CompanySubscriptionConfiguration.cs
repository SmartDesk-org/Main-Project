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

            builder.HasOne(c => c.Company)
                .WithOne(c => c.CompanySubscription)
                .HasForeignKey<CompanySubscription>(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Subscription)
                .WithMany(u => u.CompanySubscriptions)
                .HasForeignKey(u => u.SubscriptionPlanId)
                .OnDelete(DeleteBehavior.Cascade);
           
        }

    }
}
