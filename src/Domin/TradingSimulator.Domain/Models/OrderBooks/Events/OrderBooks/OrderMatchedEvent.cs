using TradingSimulator.Domain.Models.OrderBooks.Orders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Events.OrderBooks;

public class OrderMatchedEvent : IDomainEvent
{
    public OrderMatchedEvent(OrderBookId orderBookId,
        OrderId buyOrder, OrderId sellOrder, Money price, long version)
    {
        EventId = Guid.NewGuid();
        CreatedOn = DateTime.Now;

        OrderBookId = orderBookId;
        BuyOrder = buyOrder;
        SellOrder = sellOrder;
        Price = price;
        Version = version;
    }

    public Guid EventId { get; }
    public DateTime CreatedOn { get; }
    public long Version { get; set; }

    public OrderBookId OrderBookId { get; }
    public OrderId BuyOrder { get; }
    public OrderId SellOrder { get; }
    public Money Price { get; }
}