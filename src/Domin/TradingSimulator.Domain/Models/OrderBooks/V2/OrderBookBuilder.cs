using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

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
    
    public IOrderBook Build()
    {
        return new OrderBook(this);
    }
}