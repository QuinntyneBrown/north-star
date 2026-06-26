using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Infrastructure.Identity;
using NorthStar.Infrastructure.Persistence;
using NorthStar.Infrastructure.Persistence.Repositories;
using NorthStar.Infrastructure.Time;

namespace NorthStar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Provider switch: SQL Server is the default (Docker/CI/prod); "Sqlite" lets the
        // app run locally with zero infrastructure (e.g. `dotnet run` without Docker).
        var provider = configuration["Database:Provider"] ?? "SqlServer";
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<NorthStarDbContext>(options =>
        {
            if (provider.Equals("Sqlite", StringComparison.OrdinalIgnoreCase))
                options.UseSqlite(connectionString ?? "Data Source=northstar.dev.db");
            else
                options.UseSqlServer(connectionString
                    ?? "Server=localhost,1433;Database=NorthStar;User Id=sa;Password=Your_password123;TrustServerCertificate=True");
        });

        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<NorthStarDbContext>();

        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IChildProfileRepository, ChildProfileRepository>();
        services.AddScoped<IRoutineRepository, RoutineRepository>();
        services.AddScoped<IRoutineLogRepository, RoutineLogRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddSingleton<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IPinHasher, PinHasher>();
        services.AddSingleton<IClock, SystemClock>();

        return services;
    }
}
