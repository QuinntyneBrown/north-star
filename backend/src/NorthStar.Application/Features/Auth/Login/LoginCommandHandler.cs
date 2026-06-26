using MediatR;
using NorthStar.Application.Common.Abstractions;

namespace NorthStar.Application.Features.Auth.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse?>
{
    private readonly IIdentityService _identityService;

    public LoginCommandHandler(IIdentityService identityService) => _identityService = identityService;

    public Task<AuthResponse?> Handle(LoginCommand request, CancellationToken cancellationToken)
        => _identityService.AuthenticateAsync(request.Email, request.Password, cancellationToken);
}
