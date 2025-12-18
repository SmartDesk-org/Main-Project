using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    public  class SubscriptionTypesSeed:IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder.HasData
                (
                    new SubscriptionType { Id = 1, TypeName = "Basic" },
                    new SubscriptionType { Id = 2, TypeName = "Upgrade" },
                    new SubscriptionType { Id = 3, TypeName = "Renewal" }
                );
        }
    }
}
