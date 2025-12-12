using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ResourceFlow.Application.Interfaces.Auth;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Subscription;
using ResourceFlow.Application.Services;
using ResourceFlow.Application.Services.Company;
using ResourceFlow.Application.Services.Payments;
using ResourceFlow.Application.Services.Subscription;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Services;
using System.Text.Json.Serialization;

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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPaymentGateway, StripeService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Fluent validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


            //HttpContextAccessor
            services.AddHttpContextAccessor();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontEnd", policy =>
                {
                    policy.WithOrigins(configuration["FrontEndUrl:BaseUrl"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });



            //Swaggerconfiguration
           services.AddSwaggerGen(options =>
            {
              options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter token: Bearer {your token}"
                 });

              options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {

                       new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                          {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer"
                          }
                       },
                        Array.Empty<string>()
                   }
              });
            });


            return services;

            
        }
    }
}