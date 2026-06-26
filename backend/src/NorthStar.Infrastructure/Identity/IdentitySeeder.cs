using Microsoft.AspNetCore.Identity;
using NorthStar.Domain.Identity;

namespace NorthStar.Infrastructure.Identity;

/// <summary>Seeds the canonical roles at startup so they exist before the first registration.</summary>
public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
    {
        foreach (var role in Roles.All)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new ApplicationRole(role));
        }
    }
}
