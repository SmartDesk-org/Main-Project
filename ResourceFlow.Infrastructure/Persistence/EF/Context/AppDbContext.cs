using Microsoft.EntityFrameworkCore;
using ResourceFlow.Domain.Entities.Subscription;

namespace ResourceFlow.Infrastructure.Persistence.EF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

    }
}
