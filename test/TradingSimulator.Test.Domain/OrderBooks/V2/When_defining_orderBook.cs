using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_defining_orderBook
{
    private readonly OrderBookTestBuilder _sutBuilder = new();
    
    [Fact]
    public void It_gets_defined_with_required_valid_options()
    {
        var actual = _sutBuilder.Build();

        actual.Should().BeEquivalentTo(_sutBuilder);
    }

    [Fact]
    public void Title_is_required()
    {
        var act = () =>
        {
            _sutBuilder
                .WithTitle(string.Empty)
                .Build();
        };

        act.Should().Throw<OrderBookTitleIsRequired>();
    }
    
    [Fact]
    public void SymbolId_is_required()
    {
        var act = () =>
        {
            _sutBuilder
                .WithSymbolId(Guid.Empty)
                .Build();
        };

        act.Should().Throw<OrderBookSymbolIdIsRequired>();
    }
}