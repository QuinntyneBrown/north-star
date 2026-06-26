using Microsoft.EntityFrameworkCore;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Domain.Routines;

namespace NorthStar.Infrastructure.Persistence.Repositories;

public sealed class RoutineRepository : IRoutineRepository
{
    private readonly NorthStarDbContext _dbContext;

    public RoutineRepository(NorthStarDbContext dbContext) => _dbContext = dbContext;

    public void Add(Routine routine) => _dbContext.Routines.Add(routine);

    public Task<Routine?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _dbContext.Routines.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Routine>> ListActiveByChildAsync(Guid childProfileId, CancellationToken cancellationToken)
    {
        // Order client-side: SQLite cannot ORDER BY a DateTimeOffset column.
        var routines = await _dbContext.Routines
            .Where(r => r.ChildProfileId == childProfileId && r.IsActive)
            .ToListAsync(cancellationToken);

        return routines.OrderBy(r => r.CreatedAtUtc).ToList();
    }
}
