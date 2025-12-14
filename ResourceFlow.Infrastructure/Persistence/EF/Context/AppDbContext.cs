using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.Authorization;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.Finance;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System.Linq.Expressions;
using System.Reflection;

namespace ResourceFlow.Infrastructure.Persistence.EF.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _accessor;

        public AppDbContext(DbContextOptions<AppDbContext> options,
                            IHttpContextAccessor accessor)
            : base(options)
        {
            _accessor = accessor;
        }

        // Extract UserId from JWT
        private int? CurrentUserId =>
            int.TryParse(_accessor.HttpContext?.User?.FindFirst("userId")?.Value, out int id)
                ? id
                : null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply entity configurations from separate files
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // GLOBAL SOFT DELETE FILTER. Preent from returning deleted rows accidently(optional while we are using dapper for querying)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var isDeletedProperty = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));

                    var filter = Expression.Lambda(
                        Expression.Equal(isDeletedProperty, Expression.Constant(false)),
                        parameter
                    );

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }

            base.OnModelCreating(modelBuilder);
        }


        //Add logs automatically
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                // SOFT DELETE MUST BE FIRST
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    entry.Entity.DeletedBy = CurrentUserId;
                    continue; // <-- prevents ModifiedAt from being overwritten
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = CurrentUserId;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = CurrentUserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        // DbSets
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<CompanyDetails> CompanyDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        public DbSet<CompanyFloor> CompanyFloors { get; set; }
        public DbSet<AppModule> Modules { get; set; }
   
        public DbSet<RolePermission> RolePermissions { get; set; }
    }
}
