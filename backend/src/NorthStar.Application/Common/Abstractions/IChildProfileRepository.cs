using NorthStar.Domain.Children;

namespace NorthStar.Application.Common.Abstractions;

public interface IChildProfileRepository
{
    void Add(ChildProfile child);
    Task<ChildProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ChildProfile?> FindByHandleAsync(string loginHandle, CancellationToken cancellationToken);
    Task<bool> HandleExistsAsync(string loginHandle, CancellationToken cancellationToken);
    Task<IReadOnlyList<ChildProfile>> ListByFamilyAsync(Guid familyId, CancellationToken cancellationToken);
}
