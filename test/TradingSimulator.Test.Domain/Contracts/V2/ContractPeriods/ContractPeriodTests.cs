using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.V2;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts.V2.ContractPeriods;

public class ContractPeriodTests
{
    [Fact]
    public void It_gets_constructed_without_optional_references()
    {
        // Arrange
        var sutBuilder = new ContractPeriodTestBuilder();

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractPeriodOptions>(sutBuilder);
    }

    [Fact]
    public void It_gets_constructed_with_optional_references()
    {
        // Arrange
        var sutBuilder = new ContractPeriodTestBuilder()
            .WithOptionalReferences();

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractPeriodOptions>(sutBuilder);
    }

    [Theory]
    [InlineData(null, Constants.Some_Day)]
    [InlineData(Constants.Some_Day, null)]
    public void It_gets_constructed_with_infinite_Date_range(int? fromDate, int? toDate)
    {
        // Arrange
        var period = Utils.CreatePeriod(fromDate, toDate);
        var sutBuilder = new ContractPeriodTestBuilder()
            .WithFromDate(period.Item1)
            .WithToDate(period.Item2);

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractPeriodOptions>(sutBuilder);
    }

    [Theory]
    [InlineData(Constants.Some_Day, Constants.Some_Day)]
    [InlineData(Constants.Some_Day, Constants.Some_Day + 1)]
    public void It_gets_constructed_when_FromDate_is_less_than_or_equal_to_ToDate(
        int? fromDate, int? toDate)
    {
        // Arrange
        var period = Utils.CreatePeriod(fromDate, toDate);
        var sutBuilder = new ContractPeriodTestBuilder()
            .WithFromDate(period.Item1)
            .WithToDate(period.Item2);

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractPeriodOptions>(sutBuilder);
    }
    
    [Fact]
    public void It_throws_exception_when_FromDate_is_greater_than_ToDate()
    {
        // Arrange
        var sutBuilder = new ContractPeriodTestBuilder()
            .WithFromDate(Constants.From_Some_Day.AddDays(1))
            .WithToDate(Constants.From_Some_Day);

        // Act
        var act = () => sutBuilder.Build();

        // Assert
        act.Should().Throw<InvalidDateRangeException>();
    }
}