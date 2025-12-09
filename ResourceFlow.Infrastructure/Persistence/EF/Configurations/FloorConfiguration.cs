using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.FloorModels;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class FloorsConfiguration : IEntityTypeConfiguration<Floors>
    {
        public void Configure(EntityTypeBuilder<Floors> builder)
        {
            builder.HasKey(f => f.FloorId);

            builder.Property(f => f.FloorName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.CompanyId)
                   .IsRequired();

            builder.Property(f => f.FloorNumber)
                   .IsRequired();

            builder.Property(f => f.LayoutJson)
                   .HasColumnType("nvarchar(max)");
        }
    }
}
