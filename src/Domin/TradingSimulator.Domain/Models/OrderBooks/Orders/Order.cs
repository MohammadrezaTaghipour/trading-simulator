using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class Order : Entity<OrderId>
{
    public Order(OrderId id, OrderBookId orderBookId,
        TraderId traderId, SessionId sessionId, SymbolId symbolId,
        OrderCommandType cmd, OrderVolume volume, Money price,
        DateTime createdOn, OrderStateEnum state)
    {
        Id = id;
        OrderBookId = orderBookId;
        TraderId = traderId;
        SessionId = sessionId;
        SymbolId = symbolId;
        Cmd = cmd;
        Volume = volume;
        Price = price;
        CreatedOn = createdOn;
        State = state;
    }

    public OrderBookId OrderBookId { get; private set; }
    public TraderId TraderId { get; private set; }
    public SessionId SessionId { get; private set; }
    public SymbolId SymbolId { get; private set; }
    public OrderCommandType Cmd { get; private set; }
    public OrderVolume Volume { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public OrderStateEnum State { get; private set; }

    public void ModifyVolume(OrderVolume volume)
    {
        Volume = volume;
    }

    public void SetAsMatched()
    {
        State = OrderStateEnum.Matched;
    }

    public void SetAsClosed()
    {
        State = OrderStateEnum.Closed;
    }
}