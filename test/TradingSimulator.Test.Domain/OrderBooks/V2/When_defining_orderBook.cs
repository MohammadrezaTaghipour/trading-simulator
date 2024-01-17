using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;
using Xunit;

namespace TradingSimulator.Test.Domain.OrderBooks.V2;

public class When_defining_orderBook
{
    [Fact]
    public void It_gets_defined_with_required_valid_options()
    {
        var options = new OrderBookOptionsTestBuilder().Build();

        var sut = new OrderBook(options);

        sut.Should().BeEquivalentTo(options);
    }

    [Fact]
    public void Title_is_required()
    {
        var options = new OrderBookOptionsTestBuilder()
            .WithTitle(string.Empty)
            .Build();
        
        var act = () => { new OrderBook(options); };

        act.Should().Throw<OrderBookTitleIsRequired>();
    }
    
    [Fact]
    public void SymbolId_is_required()
    {
        var options = new OrderBookOptionsTestBuilder()
            .WithSymbolId(Guid.Empty)
            .Build();
        
        var act = () => { new OrderBook(options); };

        act.Should().Throw<OrderBookSymbolIdIsRequired>();
    }
}