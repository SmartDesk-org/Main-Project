using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceFlow.Domain.Entities.Authntication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Configurations.SeedData
{
    internal class UserSeed:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            string password = BCrypt.Net.BCrypt.HashPassword("123456");
            builder.HasData(
                new User {UserId=1, Email="suhailpalakkal1@gmail.com",PassWord=password,RoleId=1}
                );
        }
    }
}
