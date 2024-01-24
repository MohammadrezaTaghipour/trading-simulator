using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts;
using TradingSimulator.Domain.Models.Contracts.Periods;
using TradingSimulator.Test.Domain.Contracts.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts;

public class When_adding_period_to_contract
{
    private readonly ContractTestBuilder _sutBuilder = new();
    private readonly Contract _sut;
    private const int Today = 1;

    public When_adding_period_to_contract()
    {
        _sut = _sutBuilder.Build();
    }

    [Theory]
    [InlineData(Today, null)]
    [InlineData(Today, Today + 1)]
    public void It_gets_added_properly(int starting, int? ending)
    {
        // Arrange
        var startingDateTime = DateTime.Today.AddDays(starting);
        DateTime? endingDateTime = ending.HasValue
            ? DateTime.Today.AddDays(ending.Value)
            : null;
        var period = new ContractPeriodTestBuilder()
            .WithStartingDateTime(startingDateTime)
            .WithEndingDateTime(endingDateTime);

        // Act
        _sut.AddPeriods(period);

        // Assert
        _sut.Periods.Should().ContainEquivalentOf<IContractPeriod>(period);
    }

    [Fact]
    public void It_throws_exception_adding_periods_having_more_than_one_openEnding_atATime()
    {
        // Arrange
        var firstPeriod = new ContractPeriodTestBuilder();
        var secondPeriod = new ContractPeriodTestBuilder();

        // Act
        var act = () => _sut.AddPeriods(firstPeriod, secondPeriod);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void It_throws_exception_adding_periods_having_overlap()
    {
        // Arrange
        var firstPeriod = new ContractPeriodTestBuilder().WithOptionalOptions();
        var secondPeriod = new ContractPeriodTestBuilder()
            .WithStartingDateTime(firstPeriod.StartingDateTime)
            .WithEndingDateTime(firstPeriod.EndingDateTime);

        // Act
        var act = () => _sut.AddPeriods(firstPeriod, secondPeriod);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}