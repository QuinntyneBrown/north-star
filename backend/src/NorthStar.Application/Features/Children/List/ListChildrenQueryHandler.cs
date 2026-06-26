using MediatR;
using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Application.Features.Children.List;

public sealed class ListChildrenQueryHandler : IRequestHandler<ListChildrenQuery, IReadOnlyList<ChildProfileDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IChildProfileRepository _children;

    public ListChildrenQueryHandler(ICurrentUser currentUser, IChildProfileRepository children)
    {
        _currentUser = currentUser;
        _children = children;
    }

    public async Task<IReadOnlyList<ChildProfileDto>> Handle(ListChildrenQuery request, CancellationToken cancellationToken)
    {
        var familyId = _currentUser.FamilyId ?? Guid.Empty;
        var children = await _children.ListByFamilyAsync(familyId, cancellationToken);
        return children.Select(ChildProfileDto.From).ToList();
    }
}
