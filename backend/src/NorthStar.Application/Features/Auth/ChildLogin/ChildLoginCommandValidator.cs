using FluentValidation;

namespace NorthStar.Application.Features.Auth.ChildLogin;

public sealed class ChildLoginCommandValidator : AbstractValidator<ChildLoginCommand>
{
    public ChildLoginCommandValidator()
    {
        RuleFor(x => x.LoginHandle).NotEmpty();
        RuleFor(x => x.Pin).NotEmpty();
    }
}
