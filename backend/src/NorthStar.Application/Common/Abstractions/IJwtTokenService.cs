namespace NorthStar.Application.Common.Abstractions;

/// <summary>Port for issuing signed JWT access tokens.</summary>
public interface IJwtTokenService
{
    string CreateToken(Guid userId, string email, string displayName, string role, Guid familyId);
}
