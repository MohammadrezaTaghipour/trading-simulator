using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.V2;
using TradingSimulator.Test.Domain.Contracts.V2.TestData;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts.V2.Contracts;

public class ContractConstructionTests
{
    #region Happy Path

    [Fact]
    public void It_get_constructed_without_optional_references()
    {
        // Arrange
        var sutBuilder = new ContractTestBuilder();

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }

    [Fact]
    public void It_gets_constructed_with_optional_references()
    {
        // Arrange
        var sutBuilder = new ContractTestBuilder()
            .WithOptionalReferences();

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }

    [Theory]
    [ClassData(typeof(SinglePeriodExamples))]
    public void It_gets_constructed_with_One_optional_period(
        int? fromDate, int? toDate)
    {
        // Arrange
        var period = Utils.CreatePeriod(fromDate, toDate);
        var sutBuilder = new ContractTestBuilder()
            .AddPeriod(period.Item1, period.Item2);

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }

    [Theory]
    [ClassData(typeof(TwoPeriodsWithoutOverlapExamples))]
    public void It_gets_constructed_with_Two_optional_periods_without_overlap(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        var periods = Utils.CreatePeriod(fromDate1, toDate1, fromDate2, toDate2);
        var sutBuilder = new ContractTestBuilder()
            .AddPeriods(periods);

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }

    #endregion

    #region Exceptional Path

    [Theory]
    [ClassData(typeof(TwoPeriodsWithOverlapExamples))]
    public void It_gets_throws_constructing_with_Two_periods_with_overlap(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        var periods = Utils.CreatePeriod(fromDate1, toDate1, fromDate2, toDate2);
        var sutBuilder = new ContractTestBuilder()
            .AddPeriods(periods);

        // Act
        var act = () => sutBuilder.Build();

        // Assert
        act.Should().Throw<InvalidDataException>();
    }

    #endregion
}