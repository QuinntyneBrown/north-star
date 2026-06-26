using NorthStar.Domain.Children;

namespace NorthStar.Application.Features.Children;

public sealed record ChildProfileDto(
    Guid Id,
    string FirstName,
    int Grade,
    int? BirthYear,
    string Interests,
    string LoginHandle)
{
    public static ChildProfileDto From(ChildProfile child) =>
        new(child.Id, child.FirstName, child.Grade, child.BirthYear, child.Interests, child.LoginHandle);
}
