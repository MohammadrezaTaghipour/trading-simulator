using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.V2;
using TradingSimulator.Test.Domain.Contracts.V2.TestData;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts.V2.Contracts;

public class ContractTests
{
    private readonly ContractTestBuilder _sutBuilder = new();
    private Contract _sut;

    #region Construtor

    #region Happy Path

    [Fact]
    public void Constructor_without_optional_references_creates_object()
    {
        // Act
        _sut = _sutBuilder.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
    }

    [Fact]
    public void Constructor_with_optional_references_creates_object()
    {
        // Arrange
        _sutBuilder.WithOptionalReferences();

        // Act
        _sut = _sutBuilder.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
    }

    [Theory]
    [ClassData(typeof(SinglePeriodExamples))]
    public void Constructor_with_One_optional_period_creates_object(
        int? fromDate, int? toDate)
    {
        // Arrange
        var period = Utils.CreatePeriod(fromDate, toDate);
        _sutBuilder.AddPeriod(period.Item1, period.Item2);

        // Act
        _sut = _sutBuilder.Build();

        // Assert
        _sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
    }

    [Theory]
    [ClassData(typeof(TwoPeriodsWithoutOverlapExamples))]
    public void Constructor_with_Two_optional_periods_having_no_overlap_creates_object(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        var periods = Utils.CreatePeriod(fromDate1, toDate1, fromDate2, toDate2);
        _sutBuilder.AddPeriods(periods);

        // Act
        var sut = _sutBuilder.Build();

        // Assert
        sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
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
        _sutBuilder.AddPeriods(periods);

        // Act
        var act = () => _sutBuilder.Build();

        // Assert
        act.Should().Throw<InvalidDataException>();
    }

    #endregion

    #endregion

    #region Add Period Method

    #region Happy path

    [Theory]
    [ClassData(typeof(SinglePeriodExamples))]
    public void Add_results_in_adding_a_period_when_there_is_no_periods_added_yet(
        int? fromDate, int? toDate)
    {
        // Arrange
        Constructor_without_optional_references_creates_object();
        var period = Utils.CreatePeriod(fromDate, toDate);

        // Act
        _sutBuilder.AddPeriod(_sut, period.Item1, period.Item2);

        // Assert
        _sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
    }

    [Theory]
    [ClassData(typeof(TwoPeriodsWithoutOverlapExamples))]
    public void Add_results_in_adding_a_period_when_there_are_some_periods_added_before(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        Add_results_in_adding_a_period_when_there_is_no_periods_added_yet(fromDate1, toDate1);
        var period = Utils.CreatePeriod(fromDate2, toDate2);

        // Act
        _sutBuilder.AddPeriod(_sut, period.Item1, period.Item2);

        // Assert
        _sut.Should().BeEquivalentTo<IContractOptions>(_sutBuilder);
    }

    #endregion

    #region Exceptional Path

    [Theory]
    [ClassData(typeof(TwoPeriodsWithOverlapExamples))]
    public void Add_throws_exception_when_adding_a_period_having_overlap_with_the_period_added_before(
        int? fromDate1, int? toDate1,
        int? fromDate2, int? toDate2)
    {
        // Arrange
        Add_results_in_adding_a_period_when_there_is_no_periods_added_yet(fromDate1, toDate1);
        var period = Utils.CreatePeriod(fromDate2, toDate2);

        // Act
        var act = () => _sutBuilder.AddPeriod(_sut, period.Item1, period.Item2);

        // Assert
        act.Should().Throw<InvalidDataException>();
    }

    #endregion

    #endregion
}