using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Events.OrderBooks;

public class OrderPlacedEvent : IDomainEvent
{
    public OrderPlacedEvent(OrderId orderId, OrderBookId orderBookId,
        TraderId traderId, SessionId sessionId, SymbolId symbolId,
        OrderCommandType cmd, int volume, decimal price, long version)
    {
        EventId = Guid.NewGuid();
        PublishedOn = DateTime.Now;

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
    public DateTime PublishedOn { get; }
    public long Version { get; set; }

    public OrderId OrderId { get; }
    public OrderBookId OrderBookId { get; }
    public TraderId TraderId { get; }
    public SessionId SessionId { get; }
    public SymbolId SymbolId { get; }
    public OrderCommandType Cmd { get; }
    public int Volume { get; }
    public decimal Price { get; }
}