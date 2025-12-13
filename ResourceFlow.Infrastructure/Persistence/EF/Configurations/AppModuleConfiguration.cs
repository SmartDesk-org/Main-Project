using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authorization;

public class AppModuleConfiguration : IEntityTypeConfiguration<AppModule>
{
    public void Configure(EntityTypeBuilder<AppModule> builder)
    {
        builder.ToTable("Modules");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(m => m.Permission)
               .WithOne(p => p.Module)
               .HasForeignKey(p => p.ModuleId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
