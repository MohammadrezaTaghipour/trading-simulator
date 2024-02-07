using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.V2;
using TradingSimulator.Test.Domain.Contracts.V2.TestData;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts.V2.Contracts;

public class ContractTests
{
    #region Construtor

    #region Happy Path

    [Fact]
    public void Constructor_without_optional_references_creates_object()
    {
        // Arrange
        var sutBuilder = new ContractTestBuilder();

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }

    [Fact]
    public void Constructor_with_optional_references_creates_object()
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
    public void Constructor_with_One_optional_period_creates_object(
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
    public void Constructor_with_Two_optional_periods_having_no_overlap_creates_object(
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
    public void Constructor_should_throw_exception_with_Two_periods_having_overlap(
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

    #endregion
}