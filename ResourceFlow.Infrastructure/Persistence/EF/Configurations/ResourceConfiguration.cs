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
    public class ResourceConfiguration:IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.ResourceName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasMany(r => r.Subscriptions)
                   .WithOne(s => s.Resource)
                   .HasForeignKey(s => s.ResourceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
