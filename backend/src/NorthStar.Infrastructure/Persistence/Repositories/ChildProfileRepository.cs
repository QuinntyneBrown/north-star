using Microsoft.EntityFrameworkCore;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Domain.Children;

namespace NorthStar.Infrastructure.Persistence.Repositories;

public sealed class ChildProfileRepository : IChildProfileRepository
{
    private readonly NorthStarDbContext _dbContext;

    public ChildProfileRepository(NorthStarDbContext dbContext) => _dbContext = dbContext;

    public void Add(ChildProfile child) => _dbContext.Children.Add(child);

    public Task<ChildProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _dbContext.Children.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task<ChildProfile?> FindByHandleAsync(string loginHandle, CancellationToken cancellationToken)
        => _dbContext.Children.FirstOrDefaultAsync(c => c.LoginHandle == loginHandle, cancellationToken);

    public Task<bool> HandleExistsAsync(string loginHandle, CancellationToken cancellationToken)
        => _dbContext.Children.AnyAsync(c => c.LoginHandle == loginHandle, cancellationToken);

    public async Task<IReadOnlyList<ChildProfile>> ListByFamilyAsync(Guid familyId, CancellationToken cancellationToken)
        => await _dbContext.Children
            .Where(c => c.FamilyId == familyId)
            .OrderBy(c => c.FirstName)
            .ToListAsync(cancellationToken);
}
