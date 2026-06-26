using Microsoft.AspNetCore.Identity;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Application.Common.Exceptions;
using NorthStar.Application.Features.Auth;
using NorthStar.Domain.Families;
using NorthStar.Domain.Identity;
using NorthStar.Infrastructure.Persistence;

namespace NorthStar.Infrastructure.Identity;

public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IJwtTokenService _tokenService;
    private readonly NorthStarDbContext _dbContext;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        IJwtTokenService tokenService,
        NorthStarDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _dbContext = dbContext;
    }

    public async Task<AuthResponse> RegisterParentAsync(
        string email, string password, string displayName, string familyName, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByEmailAsync(email) is not null)
        {
            throw new ValidationException(new Dictionary<string, string[]>
            {
                ["Email"] = new[] { "An account with this email already exists." }
            });
        }

        await EnsureRolesAsync();

        var family = Family.Create(familyName);
        _dbContext.Families.Add(family);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            DisplayName = displayName,
            FamilyId = family.Id,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new ValidationException(new Dictionary<string, string[]>
            {
                ["Password"] = result.Errors.Select(e => e.Description).ToArray()
            });
        }

        await _userManager.AddToRoleAsync(user, Roles.Owner);

        var token = _tokenService.CreateToken(user.Id, email, displayName, Roles.Owner, family.Id);
        return new AuthResponse(token, email, displayName, Roles.Owner, family.Id);
    }

    public async Task<AuthResponse?> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
            return null;

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? Roles.Owner;

        var token = _tokenService.CreateToken(user.Id, email, user.DisplayName, role, user.FamilyId);
        return new AuthResponse(token, email, user.DisplayName, role, user.FamilyId);
    }

    private async Task EnsureRolesAsync()
    {
        foreach (var role in Roles.All)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new ApplicationRole(role));
        }
    }
}
