namespace NorthStar.Application.Features.Auth;

/// <summary>Returned by register/login: a signed access token plus the identity it represents.</summary>
public sealed record AuthResponse(
    string AccessToken,
    string Email,
    string DisplayName,
    string Role,
    Guid FamilyId,
    Guid? ChildId = null);
