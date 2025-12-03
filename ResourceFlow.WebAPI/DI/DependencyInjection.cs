using Microsoft.EntityFrameworkCore;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using System.Runtime.CompilerServices;

namespace ResourceFlow.WebAPI.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services,IConfiguration config)
        {

            // ----------- DbContext (EF Core) -----------

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });


            // ----------- Repositories -----------



            // ----------- Services -----------

            return services;
        }
    }
}
