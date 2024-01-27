using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public class Order : IOrder
{
    internal Order(IOrderOptions options)
    {
        Id = OrderId.New();
        OrderType = options.OrderType;
        _volume = new OrderVolume(options.Volume);
        _price = new Money(options.Price);
        CreatedOn = options.CreatedOn;
    }

    public OrderId Id { get; private set; }
    public OrderType OrderType { get; private set; }
    private OrderVolume _volume;
    private readonly Money _price;
    IOrderVolume IOrderOptions.Volume => _volume;
    OrderVolume IOrder.Volume => _volume;
    IMoneyOptions IOrderOptions.Price => _price;
    Money IOrder.Price => _price;
    public DateTime CreatedOn { get; private set; }

    public bool CanBeMatchedWith(IOrder order)
    {
        if (order.OrderType is OrderType.Buy)
            return _price <= order.Price;
        return _price >= order.Price;
    }

    public bool IsCompletelyMatched()
    {
        return _volume == 0;
    }

    public void ModifyVolume(IOrderVolume volume)
    {
        _volume -= new OrderVolume(volume);
    }
}