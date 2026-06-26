using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using NorthStar.Acceptance.Tests.Infrastructure;

namespace NorthStar.Acceptance.Tests.Features.Auth;

// ATDD acceptance test (M0 walking skeleton): a parent can register and log in,
// receiving a JWT that carries the Owner role. Written first; implementation follows.
public sealed class RegisterAndLoginTests : ApiTestBase
{
    public RegisterAndLoginTests(NorthStarApiFactory factory) : base(factory) { }

    private sealed record AuthResponseDto(string AccessToken, string Email, string DisplayName, string Role, Guid FamilyId);

    [Fact]
    public async Task Health_endpoint_reports_healthy()
    {
        var response = await Client.GetAsync("/health");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Registering_a_parent_returns_a_jwt_with_the_owner_role()
    {
        var register = new
        {
            email = "register.skeleton@example.com",
            password = "Sup3rSecret!",
            displayName = "David",
            familyName = "Brown Family"
        };

        var response = await Client.PostAsJsonAsync("/api/auth/register", register);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        body.Should().NotBeNull();
        body!.AccessToken.Should().NotBeNullOrWhiteSpace();
        body.Role.Should().Be("Owner");
        body.FamilyId.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public async Task A_registered_parent_can_log_in()
    {
        var register = new
        {
            email = "login.skeleton@example.com",
            password = "Sup3rSecret!",
            displayName = "David",
            familyName = "Brown Family"
        };
        await Client.PostAsJsonAsync("/api/auth/register", register);

        var response = await Client.PostAsJsonAsync("/api/auth/login",
            new { email = register.email, password = register.password });

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
        body!.AccessToken.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Logging_in_with_the_wrong_password_is_unauthorized()
    {
        var register = new
        {
            email = "wrongpass.skeleton@example.com",
            password = "Sup3rSecret!",
            displayName = "David",
            familyName = "Brown Family"
        };
        await Client.PostAsJsonAsync("/api/auth/register", register);

        var response = await Client.PostAsJsonAsync("/api/auth/login",
            new { email = register.email, password = "WrongPassword!" });

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Registering_with_an_invalid_email_returns_a_validation_error()
    {
        var response = await Client.PostAsJsonAsync("/api/auth/register",
            new { email = "not-an-email", password = "Sup3rSecret!", displayName = "X", familyName = "Y" });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
