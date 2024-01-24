using System.Runtime.CompilerServices;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

[assembly: InternalsVisibleTo("TradingSimulator.Test.Domain")]

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class OrderBuilder : IOrderOptions
{
    private readonly OrderVolumeOptionsBuilder _orderVolumeOptionsBuilder = new();
    private readonly MoneyOptionsBuilder _moneyOptionsBuilder = new();

    public OrderType OrderType { get; private set; }
    public IOrderVolumeOptions Volume { get; private set; }
    public IMoneyOptions Price => _moneyOptionsBuilder;
    public DateTime CreatedOn { get; private set; }


    internal OrderBuilder()
    {
    }

    public OrderBuilder WithOrderType(OrderType value)
    {
        OrderType = value;
        return this;
    }

    public OrderBuilder WithVolume(int value)
    {
        _orderVolumeOptionsBuilder.WithValue(value);
        Volume = _orderVolumeOptionsBuilder;
        return this;
    }

    public OrderBuilder WithPrice(decimal value)
    {
        _moneyOptionsBuilder.WithValue(value);
        return this;
    }

    public IOrder Build()
    {
        return new Order(this);
    }
}