using FluentAssertions;
using RandomString4Net;
using TradingSimulator.Domain.Models.Contracts.Periods;
using TradingSimulator.Test.Domain.Contracts.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Contracts;

public class When_constructing_contract
{
    private readonly ContractTestBuilder _sutBuilder = new();
    private const int Today = 1;

    [Fact]
    public void It_gets_constructed_with_required_options()
    {
        // Act
        var actual = _sutBuilder.Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutBuilder);
        actual.Id.Should().NotBe(default(Guid));
    }

    [Fact]
    public void It_gets_constructed_with_optional_options()
    {
        // Act
        var actual = _sutBuilder.WithOptionalOptions().Build();

        // Assert
        actual.Should().BeEquivalentTo(_sutBuilder);
        actual.Id.Should().NotBe(default(Guid));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Title_is_required(string title)
    {
        // Act
        var act = () => _sutBuilder.WithTitle(title).Build();

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Title_length_is_less_than_32_characters()
    {
        // Arrange 
        var randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE, 33);

        // Act
        var act = () => _sutBuilder.WithTitle(randomString).Build();

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(Today - 1)]
    [InlineData(Today)]
    [InlineData(Today + 1)]
    public void it_gets_constructed_with_openEnding_period(int starting)
    {
        // Arrange
        var startingDateTime = DateTime.Today.AddDays(starting);
        var period = new ContractPeriodTestBuilder()
            .WithStartingDateTime(startingDateTime)
            .WithEndingDateTime(null);

        // Act
        var actual = _sutBuilder.AddPeriod(period).Build();

        // Assert
        actual.Periods.Should().ContainEquivalentOf<IContractPeriod>(period);
    }

    [Fact]
    public void It_throws_exception_constructing_with_periods_having_more_than_one_openEnding_atATime()
    {
        var today = DateTime.Today.AddDays(Today);
        var periods = new List<ContractPeriodTestBuilder>()
        { 
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(today)
                .WithEndingDateTime(null),
            new ContractPeriodTestBuilder()
                .WithStartingDateTime(today)
                .WithEndingDateTime(null),
        };

        // Act
        var act = () => periods.ForEach(p => _sutBuilder.AddPeriod(p).Build());

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}