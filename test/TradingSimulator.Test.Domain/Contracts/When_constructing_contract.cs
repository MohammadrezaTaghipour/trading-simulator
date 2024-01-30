using FluentAssertions;
using TradingSimulator.Domain.Models.Contracts.Exceptions;
using TradingSimulator.Test.Domain.Contracts.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts;

public class When_constructing_contract
{
    private readonly ContractTestBuilder _sutTestBuilder = new();
    private const int Today = 1;

    [Fact]
    public void It_gets_constructed_with_required_references()
    {
        // Act
        var actual = _sutTestBuilder.Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutTestBuilder);
        actual.Id.Should().NotBe(default(Guid));
    }

    [Fact]
    public void It_gets_constructed_with_optional_references()
    {
        // Act
        var actual = _sutTestBuilder.WithOptionalReferences().Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutTestBuilder);
        actual.Id.Should().NotBe(default(Guid));
    }

    [Theory]
    [ClassData(typeof(Period))]
    public void it_gets_constructed_with_Two_periods_optional_references_without_overlap(
        int? starting1, int? ending1,
        int? starting2, int? ending2)
    {
        // Arrange
        var periods = createPeriods(starting1, ending1, starting2, ending2);
        _sutTestBuilder.AddPeriods(periods);

        // Act
        var actual = _sutTestBuilder.Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutTestBuilder);
        actual.Id.Should().NotBe(default(Guid));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void It_throws_exception_constructing_with_NullOrEmpty_Title(string title)
    {
        // Act
        var act = () => _sutTestBuilder.WithTitle(title).Build();

        // Assert
        act.Should().Throw<ContractTitleIsRequired>();
    }

    [Fact]
    public void It_throws_exception_constructing_with_Title_length_greater_than_32_characters()
    {
        // Act
        var act = () => _sutTestBuilder.WithInvalidTitleLength().Build();

        // Assert
        act.Should().Throw<ContractTitleLengthIsInvalid>();
    }

    [Fact]
    public void It_throws_exception_constructing_with_periods_having_more_than_one_unknown_EndingDateTime_atATime()
    {
        // Act
        var act = () => _sutTestBuilder
            .WithSomePeriodsHavingMoreThanOneOpenEnding()
            .Build();

        // Assert
        act.Should().Throw<OnlyOnePeriodWithUnknownEndingDateTimeIsAllowedAtATime>();
    }

    [Fact]
    public void It_It_throws_exception_constructing_with_periods_having_overlap()
    {
        // Act
        var act = () => _sutTestBuilder.WithSomeOverlappingPeriods().Build();

        // Assert
        act.Should().Throw<PeriodsWithOverlapIsNotAllowed>();
    }

    List<Tuple<DateTime?, DateTime?>> createPeriods(
        int? starting1, int? ending1,
        int? starting2, int? ending2)
    {
        var someFromDate = DateTime.Parse("2020/01/01");

        return new List<Tuple<DateTime?, DateTime?>>()
        {
            new(
                starting1.HasValue ? someFromDate.AddDays(starting1.Value) : null,
                ending1.HasValue ? someFromDate.AddDays(ending1.Value) : null),
            new(
                starting2.HasValue ? someFromDate.AddDays(starting2.Value) : null,
                ending2.HasValue ? someFromDate.AddDays(ending2.Value) : null)
        };
    }
}