using FluentAssertions;
using TradingSimulator.Test.Domain.Monies.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.Monies;

public class When_constructing_money
{
    private readonly MoneyTestBuilder _sutBuilder = new();
    
    [Fact]
    public void It_gets_constructed_with_valid_options()
    {
        var actual = _sutBuilder.Build();
        actual.Should().BeEquivalentTo(_sutBuilder);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Value_is_greater_than_zero(decimal value)
    {
        _sutBuilder.WithValue(value);

        var act = () =>
        {
            _sutBuilder.Build();
        };

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}