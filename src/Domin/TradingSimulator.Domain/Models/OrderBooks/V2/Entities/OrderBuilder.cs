using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class OrderBuilder : IOrderOptions
{
    
    private readonly OrderVolumeBuilder _orderVolumeBuilder = new();
    private readonly MoneyBuilder _moneyBuilder = new();

    public OrderType OrderType { get; private set; }
    public IOrderVolume Volume { get; private set; }
    public IMoney Price { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public OrderBuilder WithOrderType(OrderType value)
    {
        OrderType = value;
        return this;
    }

    public OrderBuilder WithVolume(int value)
    {
        _orderVolumeBuilder.WithValue(value);
        Volume = _orderVolumeBuilder;
        return this;
    }

    public OrderBuilder WithPrice(decimal value)
    {
        _moneyBuilder.WithValue(value);
        Price = _moneyBuilder;
        return this;
    }

    public Order Build()
    {
        return new Order(this);
    }
}