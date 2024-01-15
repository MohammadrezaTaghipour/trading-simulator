using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks;

public partial class OrderBook
{
    public string Title { get; private set; }
    public SessionId SessionId { get; private set; }
    public SymbolId SymbolId { get; private set; }
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders;
    
    private static readonly PriorityQueue<Order, decimal> _incomingSells = new();

    private static readonly PriorityQueue<Order, Order> _incomingBuys =
        new(new BuyOrderQueueComparer());
}