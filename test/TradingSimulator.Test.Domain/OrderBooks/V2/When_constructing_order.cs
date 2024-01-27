using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_constructing_order
{
    private readonly OrderTestBuilder _sutBuilder = new();

    [Fact]
    public void It_gets_constructed_without_optional_references()
    {
        var actual = _sutBuilder.Build();

        actual.Should().BeEquivalentTo<IOrderOptions>(_sutBuilder, opt => opt.Excluding(a => a.CreatedOn));
    }
}