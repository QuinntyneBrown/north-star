using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using NorthStar.Acceptance.Tests.Infrastructure;

namespace NorthStar.Acceptance.Tests.Features.Children;

// ATDD acceptance tests (M1): a parent (Owner) manages child profiles, and a child
// signs in with a parent-set login handle + PIN, receiving a Child-role JWT.
public sealed class ChildrenTests : ApiTestBase
{
    public ChildrenTests(NorthStarApiFactory factory) : base(factory) { }

    private sealed record AuthDto(string AccessToken, string Email, string DisplayName, string Role, Guid FamilyId);
    private sealed record ChildDto(Guid Id, string FirstName, int Grade, int? BirthYear, string Interests, string LoginHandle);

    private async Task<string> RegisterOwnerAsync(string email)
    {
        var response = await Client.PostAsJsonAsync("/api/auth/register",
            new { email, password = "Sup3rSecret!", displayName = "David", familyName = "Brown Family" });
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadFromJsonAsync<AuthDto>();
        return body!.AccessToken;
    }

    private void AuthenticateAs(string token)
        => Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    [Fact]
    public async Task Owner_can_create_and_list_a_child_profile()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.children1@example.com"));

        var create = await Client.PostAsJsonAsync("/api/children",
            new { firstName = "Maya", grade = 5, birthYear = 2017, interests = "writing,science", loginHandle = "maya-children1", pin = "1234" });

        create.StatusCode.Should().Be(HttpStatusCode.Created);
        var child = await create.Content.ReadFromJsonAsync<ChildDto>();
        child!.FirstName.Should().Be("Maya");
        child.Grade.Should().Be(5);

        var list = await Client.GetFromJsonAsync<List<ChildDto>>("/api/children");
        list.Should().ContainSingle(c => c.LoginHandle == "maya-children1");
    }

    [Fact]
    public async Task Creating_a_child_without_authentication_is_unauthorized()
    {
        var response = await Client.PostAsJsonAsync("/api/children",
            new { firstName = "Maya", grade = 5, interests = "", loginHandle = "anon-child", pin = "1234" });

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task A_child_can_log_in_with_their_handle_and_pin()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.children2@example.com"));
        await Client.PostAsJsonAsync("/api/children",
            new { firstName = "Maya", grade = 5, interests = "art", loginHandle = "maya-children2", pin = "4321" });

        Client.DefaultRequestHeaders.Authorization = null;
        var login = await Client.PostAsJsonAsync("/api/auth/child-login",
            new { loginHandle = "maya-children2", pin = "4321" });

        login.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await login.Content.ReadFromJsonAsync<AuthDto>();
        body!.Role.Should().Be("Child");
        body.DisplayName.Should().Be("Maya");
    }

    [Fact]
    public async Task Child_login_with_the_wrong_pin_is_unauthorized()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.children3@example.com"));
        await Client.PostAsJsonAsync("/api/children",
            new { firstName = "Maya", grade = 5, interests = "", loginHandle = "maya-children3", pin = "4321" });

        Client.DefaultRequestHeaders.Authorization = null;
        var login = await Client.PostAsJsonAsync("/api/auth/child-login",
            new { loginHandle = "maya-children3", pin = "0000" });

        login.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
