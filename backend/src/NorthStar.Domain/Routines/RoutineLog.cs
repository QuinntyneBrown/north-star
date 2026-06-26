using NorthStar.Domain.Common;

namespace NorthStar.Domain.Routines;

/// <summary>Records that a routine was completed on a given day, with the stars earned.</summary>
public sealed class RoutineLog : Entity
{
    public Guid RoutineId { get; private set; }
    public Guid ChildProfileId { get; private set; }
    public DateOnly Date { get; private set; }
    public int StarsAwarded { get; private set; }
    public DateTimeOffset CompletedAtUtc { get; private set; }

    private RoutineLog() { }

    public static RoutineLog Create(Guid routineId, Guid childProfileId, DateOnly date, int starsAwarded, DateTimeOffset completedAtUtc)
    {
        return new RoutineLog
        {
            Id = Guid.NewGuid(),
            RoutineId = routineId,
            ChildProfileId = childProfileId,
            Date = date,
            StarsAwarded = starsAwarded,
            CompletedAtUtc = completedAtUtc
        };
    }
}
