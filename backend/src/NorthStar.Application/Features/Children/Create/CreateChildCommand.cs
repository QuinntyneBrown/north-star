using MediatR;

namespace NorthStar.Application.Features.Children.Create;

public sealed record CreateChildCommand(
    string FirstName,
    int Grade,
    int? BirthYear,
    string Interests,
    string LoginHandle,
    string Pin) : IRequest<ChildProfileDto>;
