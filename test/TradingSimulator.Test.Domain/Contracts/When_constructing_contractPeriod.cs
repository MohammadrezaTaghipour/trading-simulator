using FluentAssertions;
using TradingSimulator.Test.Domain.Contracts.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts;

public class When_constructing_contractPeriod
{
    private readonly ContractPeriodTestBuilder _sutBuilder = new();
    private const int Today = 1;

    [Fact]
    public void It_gets_constructed_with_required_options()
    {
        // Act
        var actual = _sutBuilder.Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutBuilder);
        actual.Id.Should().NotBe(default(Guid));;
    }

    [Fact]
    public void It_gets_constructed_with_optional_options()
    {
        // Act
        var actual = _sutBuilder.WithAllOptionalOptions().Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutBuilder);
        actual.Id.Should().NotBe(Guid.Empty);
    }

    [Theory]
    [InlineData(Today, Today)]
    [InlineData(Today, Today + 1)]
    public void It_gets_constructed_with_optional_options_in_valid_boundary(int starting, int ending)
    {
        // Arrange
        var startingDateTime = DateTime.Today.AddDays(starting);
        var endingDateTime = DateTime.Today.AddDays(ending);

        // Act
        var actual = _sutBuilder
            .WithStartingDateTime(startingDateTime)
            .WithEndingDateTime(endingDateTime)
            .Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutBuilder);
        actual.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void EndingDateTime_is_greater_than_or_equal_to_StartingDateTime()
    {
        // Arrange
        var startingDateTime = DateTime.Today.AddDays(Today);
        var endingDateTime = DateTime.Today.AddDays(Today - 1);

        // Act
        var actual = () => _sutBuilder
            .WithStartingDateTime(startingDateTime)
            .WithEndingDateTime(endingDateTime)
            .Build();

        // Assert
        actual.Should().Throw<ArgumentException>();
    }
}