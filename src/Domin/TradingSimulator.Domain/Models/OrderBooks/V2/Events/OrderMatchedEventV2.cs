using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Events;

public class OrderMatchedEventV2 : IDomainEvent
{
    public OrderMatchedEventV2(OrderBookId orderBookId,
        OrderId buyOrder, OrderId sellOrder, MoneyOptions price, 
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
    public MoneyOptions Price { get; }
    public OrderVolume Volume { get; }
}