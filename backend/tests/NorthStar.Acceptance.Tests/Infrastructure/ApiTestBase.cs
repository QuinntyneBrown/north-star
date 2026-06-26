namespace NorthStar.Acceptance.Tests.Infrastructure;

/// <summary>Base for acceptance tests: shares one booted API per test class and exposes an HttpClient.</summary>
public abstract class ApiTestBase : IClassFixture<NorthStarApiFactory>
{
    protected readonly HttpClient Client;

    protected ApiTestBase(NorthStarApiFactory factory) => Client = factory.CreateClient();
}
