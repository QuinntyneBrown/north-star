using NorthStar.Domain.Common;

namespace NorthStar.Domain.Families;

/// <summary>The account boundary: one family owns child profiles, routines, projects, etc.</summary>
public sealed class Family : Entity
{
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAtUtc { get; private set; }

    private Family() { }

    public static Family Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Family name is required.", nameof(name));

        return new Family
        {
            Id = Guid.NewGuid(),
            Name = name.Trim(),
            CreatedAtUtc = DateTimeOffset.UtcNow
        };
    }
}
