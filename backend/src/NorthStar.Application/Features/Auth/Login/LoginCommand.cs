using MediatR;

namespace NorthStar.Application.Features.Auth.Login;

public sealed record LoginCommand(string Email, string Password) : IRequest<AuthResponse?>;
