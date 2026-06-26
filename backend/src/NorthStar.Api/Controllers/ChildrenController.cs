using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthStar.Application.Features.Children;
using NorthStar.Application.Features.Children.Create;
using NorthStar.Application.Features.Children.List;
using NorthStar.Domain.Identity;

namespace NorthStar.Api.Controllers;

[ApiController]
[Route("api/children")]
[Authorize(Roles = Roles.Owner)]
public sealed class ChildrenController : ControllerBase
{
    private readonly ISender _sender;

    public ChildrenController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<ActionResult<ChildProfileDto>> Create(CreateChildCommand command, CancellationToken cancellationToken)
    {
        var child = await _sender.Send(command, cancellationToken);
        return Created("/api/children", child);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ChildProfileDto>>> List(CancellationToken cancellationToken)
        => Ok(await _sender.Send(new ListChildrenQuery(), cancellationToken));
}
