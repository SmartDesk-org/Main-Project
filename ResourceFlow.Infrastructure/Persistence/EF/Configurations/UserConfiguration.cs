using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.PassWord)
                .IsRequired()
                .HasMaxLength(260);
            builder.HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<Employees>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}