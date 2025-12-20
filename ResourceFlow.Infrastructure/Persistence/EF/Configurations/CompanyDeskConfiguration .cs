using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    public class CompanyDeskConfiguration : IEntityTypeConfiguration<CompanyDesk>
    {
        public void Configure(EntityTypeBuilder<CompanyDesk> builder)
        {
            builder.ToTable("CompanyDesk");

            builder.HasKey(x => x.DeskId);

            builder.Property(x => x.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(x => x.SpecificationsJson)
                   .HasColumnType("nvarchar(max)")
                   .IsRequired();

            builder.HasOne(x => x.Company)
                    .WithMany(c => c.Desks)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Floor)
                   .WithMany(f => f.Desks)
                   .HasForeignKey(x => x.FloorId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => new { x.CompanyId, x.Status });
        }

     }
}
