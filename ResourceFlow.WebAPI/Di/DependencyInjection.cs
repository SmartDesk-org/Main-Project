using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Services;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.Dapper;
using ResourceFlow.Infrastructure.Persistence.Dapper.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Persistence.Service;
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
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
              

            );

            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();


            // Services
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<DapperContext>();
            services.AddTransient<StoredProcedureInstaller>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();





            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}