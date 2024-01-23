using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Events;

public class OrderMatchedEvent : IDomainEvent
{
    public OrderMatchedEvent(OrderBookId orderBookId,
        OrderId buyOrder, OrderId sellOrder, Shared.Monies.Money price, 
        OrderVolume volume)
    {
        EventId = Guid.NewGuid();
        CreatedOn = DateTime.Now;

        OrderBookId = orderBookId;
        BuyOrder = buyOrder;
        SellOrder = sellOrder;
        Price = price;
        Volume = volume;
    }

    public Guid EventId { get; }
    public DateTime CreatedOn { get; }

    public OrderBookId OrderBookId { get; }
    public OrderId BuyOrder { get; }
    public OrderId SellOrder { get; }
    public Shared.Monies.Money Price { get; }
    public OrderVolume Volume { get; }
}