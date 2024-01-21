using FluentAssertions;
using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderBookTestBuilder : IOrderBookOptions
{
    private readonly OrderBookBuilder _sutBuilder = new();

    public string Title { get; private set; }
    public Guid SymbolId { get; private set; }
    private readonly List<IOrderOptions> _orders = new();
    public IReadOnlyCollection<IOrderOptions> Orders => _orders.AsReadOnly();

    public OrderBookTestBuilder()
    {
        Title = "some title";
        _sutBuilder.WithTitle(Title);

        SymbolId = Guid.NewGuid();
        _sutBuilder.WithSymbolId(SymbolId);
    }

    public OrderBookTestBuilder WithTitle(string value)
    {
        _sutBuilder.WithTitle(value);
        Title = _sutBuilder.Title;
        return this;
    }

    public OrderBookTestBuilder WithSymbolId(Guid value)
    {
        _sutBuilder.WithSymbolId(value);
        SymbolId = _sutBuilder.SymbolId;
        return this;
    }

    public OrderBookTestBuilder WithOrder(Action<OrderTestBuilder> builder)
    {
        var localBuilder = new OrderTestBuilder();
        builder.Invoke(localBuilder);
        _orders.Add(localBuilder);
        return this;
    }

    public OrderBookTestBuilder WithBuyOrder(Action<OrderTestBuilder>? builder = null)
    {
        var localBuilder = new OrderTestBuilder();
        if (builder != null) builder.Invoke(localBuilder);
        localBuilder.WithOrderType(OrderType.Buy);
        _orders.Add(localBuilder);
        
        return this;
    }

    public OrderBook Build()
    {
        return _sutBuilder.Build();
    }
}