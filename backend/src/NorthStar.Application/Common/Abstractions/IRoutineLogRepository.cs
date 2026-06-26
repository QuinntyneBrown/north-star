using NorthStar.Domain.Routines;

namespace NorthStar.Application.Common.Abstractions;

public interface IRoutineLogRepository
{
    void Add(RoutineLog log);
    Task<RoutineLog?> FindAsync(Guid routineId, DateOnly date, CancellationToken cancellationToken);
    Task<IReadOnlyList<RoutineLog>> ListByChildAndDateAsync(Guid childProfileId, DateOnly date, CancellationToken cancellationToken);
    Task<IReadOnlySet<DateOnly>> ListCompletionDatesAsync(Guid childProfileId, CancellationToken cancellationToken);
}
