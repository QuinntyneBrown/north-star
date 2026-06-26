using FluentAssertions;
using NorthStar.Domain.Families;

namespace NorthStar.Domain.Tests.Families;

public sealed class FamilyTests
{
    [Fact]
    public void Create_trims_the_name_and_assigns_an_id()
    {
        var family = Family.Create("  Brown Family  ");

        family.Name.Should().Be("Brown Family");
        family.Id.Should().NotBe(Guid.Empty);
        family.CreatedAtUtc.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(1));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_rejects_a_missing_name(string? name)
    {
        var act = () => Family.Create(name!);

        act.Should().Throw<ArgumentException>();
    }
}
