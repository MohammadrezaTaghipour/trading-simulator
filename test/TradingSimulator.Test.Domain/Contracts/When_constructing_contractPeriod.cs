using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.Periods;
using TradingSimulator.Test.Domain.Contracts.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts;

public class When_constructing_contractPeriod
{
    private readonly ContractPeriodTestBuilder _sutTestBuilder = new();
    private const int Today = 1;

    [Fact]
    public void It_gets_constructed_with_required_references()
    {
        // Act
        var sut = _sutTestBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo(_sutTestBuilder);
        sut.Id.Should().NotBe(default(Guid));
    }

    [Fact]
    public void It_gets_constructed_with_optional_references()
    {
        // Act
        var sut = _sutTestBuilder.WithOptionalReferences().Build();

        // Assert
        sut.Should().BeEquivalentTo(_sutTestBuilder);
        sut.Id.Should().NotBe(default(Guid));
    }

    [Fact]
    public void It_throws_exception_constructing_with_EndingDateTime_less_than_to_StartingDateTime()
    {
        // Arrange
        var startingDateTime = DateTime.Today;
        var endingDateTime = DateTime.Today.AddDays(-1);

        // Act
        var sut = () => _sutTestBuilder
            .WithStartingDateTime(startingDateTime)
            .WithEndingDateTime(endingDateTime)
            .Build();

        // Assert
        sut.Should().Throw<PeriodEndingDateTimeIsLessThanStartingDateTime>();
    }
}