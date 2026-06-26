using NorthStar.Domain.Routines;

namespace NorthStar.Application.Common.Abstractions;

public interface IRoutineRepository
{
    void Add(Routine routine);
    Task<Routine?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Routine>> ListActiveByChildAsync(Guid childProfileId, CancellationToken cancellationToken);
}
