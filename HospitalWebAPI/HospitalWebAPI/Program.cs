using BuildingCore.Data;
using BuildingCore.Data.Entitys;
using BuildingCore.Extentions;
using BuildingCore.Interfaces;
using BuildingCore.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var assembly = typeof(Program).Assembly;
        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        builder.Services.AddAuthorization();
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer(options => // Ensure this method is accessible
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"], // Use builder.Configuration for accessing configuration
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
        builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Database")
           ));
        builder.Services.AddValidatorsFromAssembly(assembly);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
        builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        string? connectionString = builder.Configuration.GetConnectionString("Database");
        builder.Services.AddHealthChecks()
            .AddSqlServer(
                connectionString: connectionString,
                name: "Database",
                failureStatus: HealthStatus.Unhealthy);
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddTransient(s => s.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? new ClaimsPrincipal());
        builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
        builder.Services.AddTransient<IEmailSender<ApplicationUser>, SmtpEmailSender>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseExceptionHandler(_ => { });
        app.UseHttpsRedirection();
        app.MapIdentityApi<ApplicationUser>();
        app.UseAuthorization();
        app.MigrationBase();
        app.MapControllers();
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        app.Run();
    }
}
