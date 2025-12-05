using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Services;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Services;

namespace ResourceFlow.WebAPI.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register Database Context
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();


            // Services
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}