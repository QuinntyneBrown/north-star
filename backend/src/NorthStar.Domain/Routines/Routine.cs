using NorthStar.Domain.Common;

namespace NorthStar.Domain.Routines;

/// <summary>A recurring habit assigned to a child (e.g. "Read 20 minutes").</summary>
public sealed class Routine : Entity
{
    public Guid ChildProfileId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Icon { get; private set; } = string.Empty;
    public RoutineCadence Cadence { get; private set; }
    public int StarReward { get; private set; }
    public bool IsActive { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; private set; }

    private Routine() { }

    public static Routine Create(Guid childProfileId, string title, string icon, RoutineCadence cadence, int starReward)
    {
        if (childProfileId == Guid.Empty)
            throw new ArgumentException("Child is required.", nameof(childProfileId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.", nameof(title));
        if (starReward < 0)
            throw new ArgumentOutOfRangeException(nameof(starReward), "Star reward cannot be negative.");

        return new Routine
        {
            Id = Guid.NewGuid(),
            ChildProfileId = childProfileId,
            Title = title.Trim(),
            Icon = icon,
            Cadence = cadence,
            StarReward = starReward,
            IsActive = true,
            CreatedAtUtc = DateTimeOffset.UtcNow
        };
    }

    /// <summary>The starter routines every new child begins with.</summary>
    public static IReadOnlyList<Routine> DefaultsFor(Guid childProfileId) => new[]
    {
        Create(childProfileId, "Read for 20 minutes", "📖", RoutineCadence.Daily, 15),
        Create(childProfileId, "Math facts — 10 questions", "➗", RoutineCadence.Weekdays, 15),
        Create(childProfileId, "Free-write for 5 minutes", "✍️", RoutineCadence.Daily, 10)
    };
}
