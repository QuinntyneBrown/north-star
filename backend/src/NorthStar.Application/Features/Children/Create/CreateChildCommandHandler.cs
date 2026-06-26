using MediatR;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Application.Common.Exceptions;
using NorthStar.Domain.Children;
using NorthStar.Domain.Routines;

namespace NorthStar.Application.Features.Children.Create;

public sealed class CreateChildCommandHandler : IRequestHandler<CreateChildCommand, ChildProfileDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IChildProfileRepository _children;
    private readonly IRoutineRepository _routines;
    private readonly IPinHasher _pinHasher;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChildCommandHandler(
        ICurrentUser currentUser,
        IChildProfileRepository children,
        IRoutineRepository routines,
        IPinHasher pinHasher,
        IUnitOfWork unitOfWork)
    {
        _currentUser = currentUser;
        _children = children;
        _routines = routines;
        _pinHasher = pinHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<ChildProfileDto> Handle(CreateChildCommand request, CancellationToken cancellationToken)
    {
        var familyId = _currentUser.FamilyId
            ?? throw new ValidationException(new Dictionary<string, string[]>
            {
                ["Family"] = new[] { "No family context on the current user." }
            });

        var handle = request.LoginHandle.Trim().ToLowerInvariant();
        if (await _children.HandleExistsAsync(handle, cancellationToken))
        {
            throw new ValidationException(new Dictionary<string, string[]>
            {
                ["LoginHandle"] = new[] { "That login handle is already taken." }
            });
        }

        var child = ChildProfile.Create(
            familyId, request.FirstName, request.Grade, request.BirthYear, request.Interests, handle, _pinHasher.Hash(request.Pin));

        _children.Add(child);

        // Every child starts with a set of default study routines.
        foreach (var routine in Routine.DefaultsFor(child.Id))
            _routines.Add(routine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ChildProfileDto.From(child);
    }
}
