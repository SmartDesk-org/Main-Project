using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authorization;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        builder.HasKey(rp => rp.Id);

        builder.HasIndex(rp => new { rp.RoleId, rp.ModuleCode })
               .IsUnique()
               .HasFilter("[UserId] IS NULL");

        builder.HasIndex(rp => new { rp.RoleId, rp.ModuleCode, rp.UserId })
               .IsUnique()
               .HasFilter("[UserId] IS NOT NULL");


        builder.HasOne(rp => rp.Role)
               .WithMany(r => r.RolePermissions)
               .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

       builder.HasOne(rp => rp.User)
              .WithMany()
              .HasForeignKey(rp => rp.UserId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.View)
              .HasDefaultValue(false);

        builder.Property(x => x.Edit)
             .HasDefaultValue(false);

        builder.Property(x => x.Delete)
             .HasDefaultValue(false);

        builder.Property(x => x.Add)
             .HasDefaultValue(false);


    }
}
