
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.Interfaces.Authorization;
using ResourceFlow.Application.Interfaces.Company;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Payments;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Application.Interfaces.Subscriptions;
using ResourceFlow.Application.Services;
using ResourceFlow.Application.Services;
using ResourceFlow.Application.Services.Authorization;
using ResourceFlow.Application.Services.Company;
using ResourceFlow.Application.Services.Logging;
using ResourceFlow.Application.Services.Payments;
using ResourceFlow.Application.Services.Subscriptions;
using ResourceFlow.Application.Validators.Employee;
using ResourceFlow.Infrastructure.Ef.Repositories;
using ResourceFlow.Infrastructure.Persistence.Dapper;
using ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories;
using ResourceFlow.Infrastructure.Persistence.Dapper.Repositories;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Persistence.EF.Context;
using ResourceFlow.Infrastructure.Services;
using System.Data;
using System.Text.Json.Serialization;


namespace ResourceFlow.WebAPI.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );


            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeImportValidator, EmployeeImportValidator>();


            services.AddScoped<IExcelReader, ExcelReader>();
            services.AddHostedService<EmailBackgroundWorker>();
            services.AddSingleton<IBackgroundEmailQueue, BackgroundEmailQueue>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPaymentGateway, StripeService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();
            services.AddScoped<ISubscriptionPlanDapperRepository, SubscriptionDapperRepository>();

            services.AddScoped<ICompanyDapperRepository, CompanyDapperRepository>();
            services.AddScoped<IEmployeeDapperRepository, EmployeeDapperRepository>();
            services.AddScoped<IPermissionService, PermissionService>();

            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(
                    sp.GetRequiredService<IConfiguration>()
                      .GetConnectionString("DefaultConnection")
                )
            );

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            // HttpContext
            services.AddHttpContextAccessor();

            // Controllers JSON cycle handling
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // CORS
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


            // Swagger
            services.AddSwaggerGen(options =>
            {


                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {

                });
            });



            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmployeeEmailService, EmployeeEmailService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            return services;

        }

    }
}
