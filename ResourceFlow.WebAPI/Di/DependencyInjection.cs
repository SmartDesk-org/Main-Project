using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Application.Services;
using ResourceFlow.Application.Services.Notifications;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Persistence.EF.Repositories;
using ResourceFlow.Infrastructure.Services;
using ResourceFlow.WebAPI.SignalR;

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
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IDeskRepository, DeskRepository>();
            services.AddScoped<IMeetingRoomRepository, MeetingRoomRepository>();



            // Services
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationHubClientService, NotificationHubClientService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IDeskService, DeskService>();
            services.AddScoped<IMeetingRoomService, MeetingRoomService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();



             services.AddScoped<ICurrentUserService, CurrentUserService>();
            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}