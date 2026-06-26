using System.Security.Claims;
using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Api.Common;

/// <summary>Reads the authenticated caller's identity from the JWT claims on the current request.</summary>
public sealed class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _accessor;

    public CurrentUser(IHttpContextAccessor accessor) => _accessor = accessor;

    private ClaimsPrincipal? Principal => _accessor.HttpContext?.User;

    public bool IsAuthenticated => Principal?.Identity?.IsAuthenticated ?? false;

    public Guid? UserId =>
        ParseGuid(Principal?.FindFirstValue(ClaimTypes.NameIdentifier) ?? Principal?.FindFirstValue("sub"));

    public Guid? FamilyId => ParseGuid(Principal?.FindFirstValue("familyId"));

    public string? Role => Principal?.FindFirstValue(ClaimTypes.Role);

    private static Guid? ParseGuid(string? value) => Guid.TryParse(value, out var id) ? id : null;
}
