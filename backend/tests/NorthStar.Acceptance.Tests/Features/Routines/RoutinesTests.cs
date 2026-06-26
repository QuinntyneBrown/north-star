using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using NorthStar.Acceptance.Tests.Infrastructure;

namespace NorthStar.Acceptance.Tests.Features.Routines;

// ATDD acceptance tests (M2): each child gets a "today's plan" of routines; completing one
// awards stars, marks it done, and grows the streak.
public sealed class RoutinesTests : ApiTestBase
{
    public RoutinesTests(NorthStarApiFactory factory) : base(factory) { }

    private sealed record AuthDto(string AccessToken);
    private sealed record ChildDto(Guid Id, string FirstName, int Grade, int? BirthYear, string Interests, string LoginHandle);
    private sealed record TaskDto(Guid RoutineId, string Title, string Icon, int StarReward, bool Done);
    private sealed record TodayPlanDto(Guid ChildId, string Date, int Streak, int StarsToday, int CompletionPercent, List<TaskDto> Tasks);
    private sealed record CompletionDto(Guid RoutineId, bool Completed, int StarsAwarded, int CurrentStreak);

    private async Task<string> RegisterOwnerAsync(string email)
    {
        var response = await Client.PostAsJsonAsync("/api/auth/register",
            new { email, password = "Sup3rSecret!", displayName = "David", familyName = "Brown Family" });
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<AuthDto>())!.AccessToken;
    }

    private void AuthenticateAs(string? token)
        => Client.DefaultRequestHeaders.Authorization =
            token is null ? null : new AuthenticationHeaderValue("Bearer", token);

    private async Task<ChildDto> CreateChildAsync(string handle)
    {
        var response = await Client.PostAsJsonAsync("/api/children",
            new { firstName = "Maya", grade = 5, interests = "writing", loginHandle = handle, pin = "1234" });
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<ChildDto>())!;
    }

    [Fact]
    public async Task A_new_child_has_a_three_item_today_plan_with_nothing_done()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.routines1@example.com"));
        var child = await CreateChildAsync("maya-routines1");

        var plan = await Client.GetFromJsonAsync<TodayPlanDto>($"/api/children/{child.Id}/today");

        plan!.Tasks.Should().HaveCount(3);
        plan.Tasks.Should().OnlyContain(t => t.Done == false);
        plan.Streak.Should().Be(0);
        plan.CompletionPercent.Should().Be(0);
    }

    [Fact]
    public async Task Completing_a_routine_awards_stars_and_starts_a_streak()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.routines2@example.com"));
        var child = await CreateChildAsync("maya-routines2");
        var plan = await Client.GetFromJsonAsync<TodayPlanDto>($"/api/children/{child.Id}/today");
        var first = plan!.Tasks[0];

        var complete = await Client.PostAsync($"/api/routines/{first.RoutineId}/complete", null);

        complete.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await complete.Content.ReadFromJsonAsync<CompletionDto>();
        result!.Completed.Should().BeTrue();
        result.StarsAwarded.Should().BeGreaterThan(0);
        result.CurrentStreak.Should().Be(1);

        var after = await Client.GetFromJsonAsync<TodayPlanDto>($"/api/children/{child.Id}/today");
        after!.Tasks.Should().Contain(t => t.RoutineId == first.RoutineId && t.Done);
        after.StarsToday.Should().BeGreaterThan(0);
        after.CompletionPercent.Should().BeGreaterThan(0);
        after.Streak.Should().Be(1);
    }

    [Fact]
    public async Task A_child_can_view_their_own_plan_after_pin_login()
    {
        AuthenticateAs(await RegisterOwnerAsync("owner.routines3@example.com"));
        var child = await CreateChildAsync("maya-routines3");

        AuthenticateAs(null);
        var login = await Client.PostAsJsonAsync("/api/auth/child-login", new { loginHandle = "maya-routines3", pin = "1234" });
        AuthenticateAs((await login.Content.ReadFromJsonAsync<AuthDto>())!.AccessToken);

        var plan = await Client.GetFromJsonAsync<TodayPlanDto>($"/api/children/{child.Id}/today");

        plan!.Tasks.Should().HaveCount(3);
    }

    [Fact]
    public async Task Fetching_a_today_plan_requires_authentication()
    {
        var response = await Client.GetAsync($"/api/children/{Guid.NewGuid()}/today");

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
