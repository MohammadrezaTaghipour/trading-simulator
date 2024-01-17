using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Events.OrderBooks;

public class OrderPlacedEvent : IDomainEvent
{
    public OrderPlacedEvent(OrderId orderId, OrderBookId orderBookId,
        TraderId traderId, OrderType orderType, OrderVolume volume, Money price)
    {
        EventId = Guid.NewGuid();
        CreatedOn = DateTime.Now;

        OrderId = orderId;
        OrderBookId = orderBookId;
        TraderId = traderId;
        OrderType = orderType;
        Volume = volume;
        Price = price;
    }

    public Guid EventId { get; }
    public DateTime CreatedOn { get; }

    public OrderId OrderId { get; }
    public OrderBookId OrderBookId { get; }
    public TraderId TraderId { get; }
    public OrderType OrderType { get; }
    public OrderVolume Volume { get; }
    public Money Price { get; }
}