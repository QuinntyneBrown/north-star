using NorthStar.Domain.Common;

namespace NorthStar.Domain.Children;

/// <summary>A child the family is guiding — the anchor for routines, projects, sports and matches.</summary>
public sealed class ChildProfile : Entity
{
    public Guid FamilyId { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public int Grade { get; private set; }
    public int? BirthYear { get; private set; }
    public string Interests { get; private set; } = string.Empty;
    public string LoginHandle { get; private set; } = string.Empty;
    public string PinHash { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAtUtc { get; private set; }

    private ChildProfile() { }

    public static ChildProfile Create(
        Guid familyId, string firstName, int grade, int? birthYear, string interests, string loginHandle, string pinHash)
    {
        if (familyId == Guid.Empty)
            throw new ArgumentException("Family is required.", nameof(familyId));
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(loginHandle))
            throw new ArgumentException("Login handle is required.", nameof(loginHandle));
        if (grade is < 1 or > 12)
            throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 1 and 12.");

        return new ChildProfile
        {
            Id = Guid.NewGuid(),
            FamilyId = familyId,
            FirstName = firstName.Trim(),
            Grade = grade,
            BirthYear = birthYear,
            Interests = (interests ?? string.Empty).Trim(),
            LoginHandle = loginHandle.Trim().ToLowerInvariant(),
            PinHash = pinHash,
            CreatedAtUtc = DateTimeOffset.UtcNow
        };
    }
}
