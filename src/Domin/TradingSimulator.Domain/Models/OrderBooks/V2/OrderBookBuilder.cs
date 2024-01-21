using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBookBuilder : IOrderBookOptions
{
    public string Title { get; private set;}
    public Guid SymbolId { get; private set;}
    private readonly List<IOrderOptions> _orders = new();
    public IReadOnlyCollection<IOrderOptions> Orders => _orders.AsReadOnly();
    

    public OrderBookBuilder WithTitle(string value)
    {
        Title = value;
        return this;
    }
    
    public OrderBookBuilder WithSymbolId(Guid value)
    {
        SymbolId = value;
        return this;
    }
    
    public OrderBookBuilder AddOrder(Action<OrderBuilder> builder)
    {
        var localBuilder = new OrderBuilder();
        builder(localBuilder);
        _orders.Add(localBuilder);
        return this;
    }
    
    public OrderBookBuilder AddOrder(IOrderOptions order)
    {
        _orders.Add(order);
        return this;
    }
    
    
    public OrderBook Build()
    {
        return new OrderBook(this);
    }
}