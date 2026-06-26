using MediatR;
using NorthStar.Application.Common.Abstractions;
using NorthStar.Domain.Identity;

namespace NorthStar.Application.Features.Auth.ChildLogin;

public sealed class ChildLoginCommandHandler : IRequestHandler<ChildLoginCommand, AuthResponse?>
{
    private readonly IChildProfileRepository _children;
    private readonly IPinHasher _pinHasher;
    private readonly IJwtTokenService _tokenService;

    public ChildLoginCommandHandler(
        IChildProfileRepository children, IPinHasher pinHasher, IJwtTokenService tokenService)
    {
        _children = children;
        _pinHasher = pinHasher;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse?> Handle(ChildLoginCommand request, CancellationToken cancellationToken)
    {
        var handle = request.LoginHandle.Trim().ToLowerInvariant();
        var child = await _children.FindByHandleAsync(handle, cancellationToken);
        if (child is null || !_pinHasher.Verify(child.PinHash, request.Pin))
            return null;

        var token = _tokenService.CreateToken(child.Id, child.LoginHandle, child.FirstName, Roles.Child, child.FamilyId);
        return new AuthResponse(token, child.LoginHandle, child.FirstName, Roles.Child, child.FamilyId, child.Id);
    }
}
