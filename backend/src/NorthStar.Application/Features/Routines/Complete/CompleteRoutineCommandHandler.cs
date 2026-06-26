using MediatR;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Application.Common.Exceptions;
using NorthStar.Domain.Routines;

namespace NorthStar.Application.Features.Routines.Complete;

public sealed class CompleteRoutineCommandHandler : IRequestHandler<CompleteRoutineCommand, RoutineCompletionDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IChildProfileRepository _children;
    private readonly IRoutineRepository _routines;
    private readonly IRoutineLogRepository _logs;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClock _clock;

    public CompleteRoutineCommandHandler(
        ICurrentUser currentUser,
        IChildProfileRepository children,
        IRoutineRepository routines,
        IRoutineLogRepository logs,
        IUnitOfWork unitOfWork,
        IClock clock)
    {
        _currentUser = currentUser;
        _children = children;
        _routines = routines;
        _logs = logs;
        _unitOfWork = unitOfWork;
        _clock = clock;
    }

    public async Task<RoutineCompletionDto> Handle(CompleteRoutineCommand request, CancellationToken cancellationToken)
    {
        var routine = await _routines.GetByIdAsync(request.RoutineId, cancellationToken);
        if (routine is null)
            throw new NotFoundException("Routine", request.RoutineId);

        var child = await _children.GetByIdAsync(routine.ChildProfileId, cancellationToken);
        if (child is null || child.FamilyId != _currentUser.FamilyId)
            throw new NotFoundException("Routine", request.RoutineId);

        var today = DateOnly.FromDateTime(_clock.UtcNow.UtcDateTime);

        // Completing the same routine twice in a day is idempotent — no double stars.
        var existing = await _logs.FindAsync(routine.Id, today, cancellationToken);
        var starsAwarded = existing?.StarsAwarded ?? routine.StarReward;
        if (existing is null)
        {
            _logs.Add(RoutineLog.Create(routine.Id, child.Id, today, routine.StarReward, _clock.UtcNow));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        var streak = StreakCalculator.Current(await _logs.ListCompletionDatesAsync(child.Id, cancellationToken), today);

        return new RoutineCompletionDto(routine.Id, true, starsAwarded, streak);
    }
}
