using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authntication;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyDetails>
    {
        public void Configure(EntityTypeBuilder<CompanyDetails> builder)
        {
            builder.ToTable("CompanyDetails");

            builder.HasKey(c => c.CompanyId);
        }
    }
}
