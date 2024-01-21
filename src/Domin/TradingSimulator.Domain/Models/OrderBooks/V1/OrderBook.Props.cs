using TradingSimulator.Domain.Models.OrderBooks.V1.Comparers;
using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;

namespace TradingSimulator.Domain.Models.OrderBooks.V1;

public partial class OrderBook
{
    public string Title { get; private set; }
    public SessionId SessionId { get; private set; }
    public Guid SymbolId { get; private set; }
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders;

    private readonly PriorityQueue<Order, Order> _incomingSellOrderQueue = 
        new(new SellOrderQueueComparer());

    private readonly PriorityQueue<Order, Order> _incomingBuyOrderQueue =
        new(new BuyOrderQueueComparer());
}