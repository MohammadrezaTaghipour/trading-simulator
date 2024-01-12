using TradingSimulator.Infrastructure.Domain;
using TradingSimulator.Domain.Models.OrderBooks.Args;

namespace TradingSimulator.Domain.Models.OrderBooks;

public class OrderBook : AggregateRoot<OrderBookId>
{
    private OrderBook()
    {
    }


    public void PlaceOrder(PlaceOrderArg arg)
    {
        var orderId = new OrderId(_orders.Count + 1);
        _orders.Add(new Order(orderId, arg.TraderId, arg.SessionId,
            arg.SymbolId, arg.Cmd, arg.Volume, arg.Price));
    }

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders;
}