namespace NorthStar.Application.Common.Abstractions;

/// <summary>Ambient information about the authenticated caller, sourced from the JWT.</summary>
public interface ICurrentUser
{
    bool IsAuthenticated { get; }
    Guid? UserId { get; }
    Guid? FamilyId { get; }
    string? Role { get; }
}
