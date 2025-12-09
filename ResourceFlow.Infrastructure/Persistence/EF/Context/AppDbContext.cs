using Microsoft.EntityFrameworkCore;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System.Reflection;

namespace ResourceFlow.Infrastructure.Persistence.EF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Authentication
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        // Company & Employees
        public DbSet<Employees> Employees { get; set; }
        public DbSet<CompanyDetails> CompanyDetails { get; set; }

        // Finance
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Billing> Billing { get; set; }

        // Notifications
        public DbSet<Notification> Notifications { get; set; }

        // Resources
        public DbSet<Resource> Resources { get; set; }

        // Subscriptions (both old and new)
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all IEntityTypeConfiguration<T> from Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
