
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.Finance;

<<<<<<< HEAD
using ResourceFlow.Domain.Entities.SubscriptionModels;
=======
using ResourceFlow.Domain.Entities.Finance;
>>>>>>> dc0f61bb97bbd76c8507205e76d30066cf045f75
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


        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<CompanyDetails> CompanyDetails { get; set; }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<CompanySubscription> companySubscriptions { get; set; }


        public DbSet<Payment> Payments { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
