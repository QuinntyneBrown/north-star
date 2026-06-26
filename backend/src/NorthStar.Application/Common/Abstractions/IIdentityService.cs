using NorthStar.Application.Features.Auth;

namespace NorthStar.Application.Common.Abstractions;

/// <summary>Port for identity operations; implemented in Infrastructure over ASP.NET Identity.</summary>
public interface IIdentityService
{
    Task<AuthResponse> RegisterParentAsync(
        string email, string password, string displayName, string familyName, CancellationToken cancellationToken);

    Task<AuthResponse?> AuthenticateAsync(
        string email, string password, CancellationToken cancellationToken);
}
