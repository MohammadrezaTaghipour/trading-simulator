using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderBookTestBuilder : IOrderBookOptions
{
    private readonly OrderBookBuilder _sutBuilder = new();

    public string Title => _sutBuilder.Title;
    public Guid SymbolId => _sutBuilder.SymbolId;
    public IEnumerable<IOrderOptions> Orders => _sutBuilder.Orders;

    public OrderBookTestBuilder()
    {
        _sutBuilder.WithTitle("some title");
        _sutBuilder.WithSymbolId(Guid.NewGuid());
    }

    public OrderBookTestBuilder WithTitle(string value)
    {
        _sutBuilder.WithTitle(value);
        return this;
    }

    public OrderBookTestBuilder WithSymbolId(Guid value)
    {
        _sutBuilder.WithSymbolId(value);
        return this;
    }

    public OrderBook Build()
    {
        return (_sutBuilder.Build() as OrderBook)!;
    }
}