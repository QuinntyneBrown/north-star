using Microsoft.EntityFrameworkCore;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Domain.Routines;

namespace NorthStar.Infrastructure.Persistence.Repositories;

public sealed class RoutineLogRepository : IRoutineLogRepository
{
    private readonly NorthStarDbContext _dbContext;

    public RoutineLogRepository(NorthStarDbContext dbContext) => _dbContext = dbContext;

    public void Add(RoutineLog log) => _dbContext.RoutineLogs.Add(log);

    public Task<RoutineLog?> FindAsync(Guid routineId, DateOnly date, CancellationToken cancellationToken)
        => _dbContext.RoutineLogs.FirstOrDefaultAsync(l => l.RoutineId == routineId && l.Date == date, cancellationToken);

    public async Task<IReadOnlyList<RoutineLog>> ListByChildAndDateAsync(Guid childProfileId, DateOnly date, CancellationToken cancellationToken)
        => await _dbContext.RoutineLogs
            .Where(l => l.ChildProfileId == childProfileId && l.Date == date)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlySet<DateOnly>> ListCompletionDatesAsync(Guid childProfileId, CancellationToken cancellationToken)
    {
        var dates = await _dbContext.RoutineLogs
            .Where(l => l.ChildProfileId == childProfileId)
            .Select(l => l.Date)
            .Distinct()
            .ToListAsync(cancellationToken);

        return dates.ToHashSet();
    }
}
