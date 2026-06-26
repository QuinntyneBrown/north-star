using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Infrastructure.Persistence;

public sealed class EfUnitOfWork : IUnitOfWork
{
    private readonly NorthStarDbContext _dbContext;

    public EfUnitOfWork(NorthStarDbContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);
}
