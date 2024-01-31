using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.V2;
using TradingSimulator.Test.Domain.Contracts.V2.TestData;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts.V2.Contracts;

public class ContractTests
{
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
    public void It_gets_constructed_with_One_period_without_overlap(int? fromDate, int? toDate)
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
    [ClassData(typeof(TwoPeriodsExamples))]
    public void It_gets_constructed_with_Two_period_without_overlap(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        var periods = Utils.CreatePeriod(fromDate1, toDate1,fromDate2, toDate2);
        var sutBuilder = new ContractTestBuilder()
            .AddPeriods(periods);

        // Act
        var sut = sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(sutBuilder);
    }
}