using TradingSimulator.Domain.Models.Traders;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class Order : Entity<OrderId>
{
    public Order(OrderId id, OrderBookId orderBookId,
        TraderId traderId, OrderType type,
        OrderVolume volume, Money price,
        DateTime createdOn)
    {
        Id = id;
        OrderBookId = orderBookId;
        TraderId = traderId;
        Type = type;
        Volume = volume;
        Price = price;
        CreatedOn = createdOn;
        State = OrderStateEnum.Pending;
    }

    public OrderBookId OrderBookId { get; private set; }
    public TraderId TraderId { get; private set; }
    public OrderType Type { get; private set; }
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