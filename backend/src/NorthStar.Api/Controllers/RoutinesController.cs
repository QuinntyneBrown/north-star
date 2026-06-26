using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthStar.Application.Features.Routines;
using NorthStar.Application.Features.Routines.Complete;
using NorthStar.Application.Features.Routines.GetToday;

namespace NorthStar.Api.Controllers;

[ApiController]
[Authorize]
public sealed class RoutinesController : ControllerBase
{
    private readonly ISender _sender;

    public RoutinesController(ISender sender) => _sender = sender;

    [HttpGet("api/children/{childId:guid}/today")]
    public async Task<ActionResult<TodayPlanDto>> Today(Guid childId, CancellationToken cancellationToken)
        => Ok(await _sender.Send(new GetTodayPlanQuery(childId), cancellationToken));

    [HttpPost("api/routines/{routineId:guid}/complete")]
    public async Task<ActionResult<RoutineCompletionDto>> Complete(Guid routineId, CancellationToken cancellationToken)
        => Ok(await _sender.Send(new CompleteRoutineCommand(routineId), cancellationToken));
}
