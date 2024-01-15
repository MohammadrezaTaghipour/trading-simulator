using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Events.OrderBooks;

public class OrderPlacedEvent : IDomainEvent
{
    public OrderPlacedEvent(OrderId orderId, OrderBookId orderBookId,
        TraderId traderId, SessionId sessionId, SymbolId symbolId,
        OrderType cmd, OrderVolume volume, Money price, long version)
    {
        EventId = Guid.NewGuid();
        CreatedOn = DateTime.Now;

        OrderId = orderId;
        OrderBookId = orderBookId;
        TraderId = traderId;
        SessionId = sessionId;
        SymbolId = symbolId;
        Cmd = cmd;
        Volume = volume;
        Price = price;
        Version = version;
    }

    public Guid EventId { get; }
    public DateTime CreatedOn { get; }
    public long Version { get; set; }

    public OrderId OrderId { get; }
    public OrderBookId OrderBookId { get; }
    public TraderId TraderId { get; }
    public SessionId SessionId { get; }
    public SymbolId SymbolId { get; }
    public OrderType Cmd { get; }
    public OrderVolume Volume { get; }
    public Money Price { get; }
}