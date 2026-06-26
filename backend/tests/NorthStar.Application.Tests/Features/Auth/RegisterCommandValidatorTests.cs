using FluentAssertions;
using NorthStar.Application.Features.Auth.Register;

namespace NorthStar.Application.Tests.Features.Auth;

public sealed class RegisterCommandValidatorTests
{
    private readonly RegisterCommandValidator _validator = new();

    [Fact]
    public void Accepts_a_well_formed_command()
    {
        var result = _validator.Validate(new RegisterCommand(
            "parent@example.com", "Sup3rSecret!", "David", "Brown Family"));

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("not-an-email", "Sup3rSecret!")]
    [InlineData("parent@example.com", "short")]
    public void Rejects_invalid_email_or_weak_password(string email, string password)
    {
        var result = _validator.Validate(new RegisterCommand(email, password, "David", "Brown Family"));

        result.IsValid.Should().BeFalse();
    }
}
