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
    public class SubscriptionConfigurations:IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);

            builder.ToTable("Subscriptions");

            builder.HasOne(u => u.Type)
                .WithMany(u =>u.Types)
                .HasForeignKey(u => u.TypeId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
