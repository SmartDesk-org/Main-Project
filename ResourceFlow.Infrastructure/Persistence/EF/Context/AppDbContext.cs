using Microsoft.EntityFrameworkCore;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.EF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


      public  DbSet<Role> Roles { get; set; }
      public  DbSet<User> Users { get; set; }
      public  DbSet<Employees> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
