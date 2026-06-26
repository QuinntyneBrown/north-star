using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NorthStar.Infrastructure.Persistence;

namespace NorthStar.Acceptance.Tests.Infrastructure;

/// <summary>
/// Boots the real API in-memory for acceptance tests. Uses a shared, open SQLite
/// connection so the ATDD loop runs without Docker. In CI (Docker available) this is
/// where a Testcontainers SQL Server would be substituted for full prod fidelity.
/// </summary>
public sealed class NorthStarApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Use the "Testing" environment but keep appsettings.json's Jwt section, so token
        // creation (IOptions, lazy) and validation (read in Program, eager) share one key.
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<NorthStarDbContext>>();
            services.RemoveAll<NorthStarDbContext>();
            services.AddDbContext<NorthStarDbContext>(options => options.UseSqlite(_connection));
        });
    }

    public async Task InitializeAsync()
    {
        await _connection.OpenAsync();
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<NorthStarDbContext>();
        await db.Database.EnsureCreatedAsync();
    }

    public new async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
        await base.DisposeAsync();
    }
}
