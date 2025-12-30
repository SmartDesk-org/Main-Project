

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    public class ResourceTypeSeed : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.HasData(
                new ResourceType
                {
                    Id = 1,
                    Name = "Desk",
                    Icon="desk.png",
                    DefaultHeight=60,
                    DefaultWidth=60,
                    IsActive = true
                },
                new ResourceType
                {
                    Id = 2,
                    Name = "MeetingRoom",
                    Icon="meetingroom.png",
                    DefaultWidth=120,
                    DefaultHeight=120,
                    IsActive = true
                }
            );
        }
    }
}
