using System.Runtime.CompilerServices;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

[assembly: InternalsVisibleTo("TradingSimulator.Test.Domain")]

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public class OrderBuilder : IOrderOptions
{
    private readonly OrderVolumeBuilder _orderVolumeBuilder = new();
    private readonly MoneyBuilder _moneyBuilder = new();

    public OrderType OrderType { get; private set; }
    public IOrderVolumeOptions Volume => _orderVolumeBuilder;
    public IMoney Price => _moneyBuilder;
    public DateTime CreatedOn { get; private set; }

    public OrderBuilder WithOrderType(OrderType value)
    {
        OrderType = value;
        return this;
    }
    
    public OrderBuilder WithOrderType(string value)
    {
        OrderType = (OrderType)Enum.Parse(typeof(OrderType), value);
        return this;
    }

    public OrderBuilder WithVolume(int value)
    {
        _orderVolumeBuilder.WithValue(value);
        return this;
    }

    public OrderBuilder WithPrice(decimal value)
    {
        _moneyBuilder.WithValue(value);
        return this;
    }

    public IOrder Build()
    {
        return new Order(this);
    }
}