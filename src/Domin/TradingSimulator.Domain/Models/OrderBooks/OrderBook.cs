using TradingSimulator.Domain.Events;
using TradingSimulator.Domain.Events.OrderBooks;
using TradingSimulator.Infrastructure.Domain;
using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks;

public class OrderBook : AggregateRoot<OrderBookId>
{
    private OrderBook()
    {
    }

    public OrderBook(DefineOrderBookArg arg)
    {
        Id = arg.Id;
        Title = arg.Title;
        SessionId = arg.SessionId;
        SymbolId = arg.SymbolId;

        CurrentVersion += 1;
    }

    public void PlaceOrder(PlaceOrderArg arg)
    {
        var orderId = new OrderId(_orders.Count + 1);
        _orders.Add(new Order(orderId, arg.TraderId, arg.SessionId,
            arg.SymbolId, arg.Cmd, arg.Volume, arg.Price));
        CurrentVersion += 1;

        Apply(new OrderPlacedEvent(orderId, this.Id, arg.TraderId,
            arg.SessionId, arg.SymbolId, arg.Cmd, arg.Volume, 
            arg.Price, CurrentVersion));
    }

    public string Title { get; private set; }
    public SessionId SessionId { get; private set; }
    public SymbolId SymbolId { get; private set; }
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders;
}