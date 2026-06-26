using MediatR;

namespace NorthStar.Application.Features.Children.List;

public sealed record ListChildrenQuery : IRequest<IReadOnlyList<ChildProfileDto>>;
