using MediatR;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Application.Common.Exceptions;
using NorthStar.Domain.Routines;

namespace NorthStar.Application.Features.Routines.GetToday;

public sealed class GetTodayPlanQueryHandler : IRequestHandler<GetTodayPlanQuery, TodayPlanDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IChildProfileRepository _children;
    private readonly IRoutineRepository _routines;
    private readonly IRoutineLogRepository _logs;
    private readonly IClock _clock;

    public GetTodayPlanQueryHandler(
        ICurrentUser currentUser,
        IChildProfileRepository children,
        IRoutineRepository routines,
        IRoutineLogRepository logs,
        IClock clock)
    {
        _currentUser = currentUser;
        _children = children;
        _routines = routines;
        _logs = logs;
        _clock = clock;
    }

    public async Task<TodayPlanDto> Handle(GetTodayPlanQuery request, CancellationToken cancellationToken)
    {
        var child = await _children.GetByIdAsync(request.ChildId, cancellationToken);
        if (child is null || child.FamilyId != _currentUser.FamilyId)
            throw new NotFoundException("Child", request.ChildId);

        var today = DateOnly.FromDateTime(_clock.UtcNow.UtcDateTime);
        var routines = await _routines.ListActiveByChildAsync(child.Id, cancellationToken);
        var todayLogs = await _logs.ListByChildAndDateAsync(child.Id, today, cancellationToken);
        var doneRoutineIds = todayLogs.Select(l => l.RoutineId).ToHashSet();

        var tasks = routines
            .Select(r => new TodayTaskDto(r.Id, r.Title, r.Icon, r.StarReward, doneRoutineIds.Contains(r.Id)))
            .ToList();

        var starsToday = todayLogs.Sum(l => l.StarsAwarded);
        var completion = tasks.Count == 0
            ? 0
            : (int)Math.Round(100.0 * tasks.Count(t => t.Done) / tasks.Count);

        var streak = StreakCalculator.Current(await _logs.ListCompletionDatesAsync(child.Id, cancellationToken), today);

        return new TodayPlanDto(child.Id, today, streak, starsToday, completion, tasks);
    }
}
