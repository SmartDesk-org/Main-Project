﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
﻿using Hangfire;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OfficeOpenXml;
using ResourceFlow.Application.Interfaces;
using ResourceFlow.Application.Interfaces.Persistence;
using ResourceFlow.WebAPI.DI;
using ResourceFlow.WebAPI.Middleware;
using Serilog;
using System.Text;
using System.Threading.RateLimiting;




Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/app-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
// Controllers & JSON options
builder.Services.AddControllers(options =>
{
    // 🔒 GLOBAL DENY-BY-DEFAULT
    var defaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(defaultPolicy));
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
        System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();


// Swagger configuration (single registration)
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();




builder.Services.AddProjectServices(builder.Configuration);
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


var jwt = builder.Configuration.GetSection("JwtSettings");
var secret = jwt["Secret"] ?? throw new Exception("Jwt Secret missing");
var issuer = jwt["Issuer"];
var audience = jwt["Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// In Program.cs

.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            // 1. Header Check
            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrWhiteSpace(authHeader) && authHeader.StartsWith("Bearer "))
            {
                context.Token = authHeader.Substring("Bearer ".Length).Trim();
                return Task.CompletedTask;
            }

            // 2. Cookie Check
            if (context.Request.Cookies.ContainsKey("accessToken"))
            {
                context.Token = context.Request.Cookies["accessToken"];
                return Task.CompletedTask;
            }

            // 👇👇👇 THIS IS THE MISSING PART YOU NEED 👇👇👇
            // 3. Query String Check (REQUIRED because you used skipNegotiation: true)
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/uploadProgressHub")))
            {
                context.Token = accessToken;
            }
            // 👆👆👆 END OF CRITICAL FIX 👆👆👆

            return Task.CompletedTask;
        }
    };

    // (Keep your TokenValidationParameters exactly as they are)
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();


builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Fixed", opt =>
    {
        opt.Window = TimeSpan.FromMinutes(1);
        opt.PermitLimit = 5;
        opt.QueueLimit = 0;
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});


var app = builder.Build();


//background job scheduling 
app.UseHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<ISubscriptionJob>(
    "daily-subscription-check",
    job => job.CheckAndUpdateSubscriptionsAsync(),
    Cron.Daily(2,30)
    );


//StoredProcedure installer;

var autoInstallEnabled =
    builder.Configuration.GetValue<bool>("Database:AutoInstallStoredProcedures");

if (autoInstallEnabled)
{
    using var scope = app.Services.CreateScope();
    var installer = scope.ServiceProvider
        .GetRequiredService<IStoredProcedureInstaller>();

    await installer.InstallAsync();
}
else
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation(
        "SP auto-execution skipped. Environment: {Env}",
        app.Environment.EnvironmentName);
}
if (app.Environment.IsProduction())
{

}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontEnd");

// app.UseHttpsRedirection();

// app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<UploadProgressHub>("/uploadProgressHub");

app.MapControllers();

app.Run();
