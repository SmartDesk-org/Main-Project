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
    public class SubscriptionsConfigurations:IEntityTypeConfiguration<Subscriptions>
    {
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SubscriptionName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.PriceMonthly)
                   .IsRequired();

            builder.Property(s => s.PriceYearly)
                   .IsRequired();

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.HasOne(s => s.Resource)
                   .WithMany(r => r.Subscriptions)
                   .HasForeignKey(s => s.ResourceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
