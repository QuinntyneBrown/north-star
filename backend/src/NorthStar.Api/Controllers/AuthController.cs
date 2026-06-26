using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthStar.Application.Features.Auth;
using NorthStar.Application.Features.Auth.ChildLogin;
using NorthStar.Application.Features.Auth.Login;
using NorthStar.Application.Features.Auth.Register;

namespace NorthStar.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender) => _sender = sender;

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterCommand command, CancellationToken cancellationToken)
        => Ok(await _sender.Send(command, cancellationToken));

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginCommand command, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(command, cancellationToken);
        return response is null ? Unauthorized() : Ok(response);
    }

    [HttpPost("child-login")]
    public async Task<ActionResult<AuthResponse>> ChildLogin(ChildLoginCommand command, CancellationToken cancellationToken)
    {
        var response = await _sender.Send(command, cancellationToken);
        return response is null ? Unauthorized() : Ok(response);
    }
}
