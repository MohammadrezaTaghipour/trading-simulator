using FluentAssertions;
using TradingSimulator.Domain.Models.Shared.Monies.Exceptions;
using Xunit;

namespace TradingSimulator.Test.Domain.Monies;

public class When_constructing_money
{
    private readonly MoneyTestBuilder _sutBuilder = new();
    
    [Fact]
    public void It_gets_constructed_with_required_references()
    {
        var actual = _sutBuilder.Build();
        actual.Should().BeEquivalentTo(_sutBuilder);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throws_exception_when_Value_is_less_than_zero(decimal value)
    {
        _sutBuilder.WithValue(value);

        var act = () =>
        {
            _sutBuilder.Build();
        };

        act.Should().Throw<MoneyCanNotInitializedWithLessThanZero>();
    }
}