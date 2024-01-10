using OrderBookManagement.Domain.Models.Sessions;
using OrderBookManagement.Domain.Models.Symbols;
using OrderBookManagement.Domain.Models.Traders;
using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.OrderBooks;

public class Order : Entity<OrderId>
{
    public Order(OrderId id, TraderId traderId, SessionId sessionId,
        SymbolId symbolId, OrderCommandType cmd, int volume, decimal price)
    {
        Id = id;
        TraderId = traderId;
        SessionId = sessionId;
        SymbolId = symbolId;
        Cmd = cmd;
        Volume = volume;
        Price = price;
    }

    public TraderId TraderId { get; private set; }
    public SessionId SessionId { get; private set; }
    public SymbolId SymbolId { get; private set; }
    public OrderCommandType Cmd { get; private set; }
    public int Volume { get; private set; }
    public decimal Price { get; private set; }
}