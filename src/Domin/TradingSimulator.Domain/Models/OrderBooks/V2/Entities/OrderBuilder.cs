using System.Runtime.CompilerServices;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

[assembly: InternalsVisibleTo("TradingSimulator.Test.Domain")]

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class OrderBuilder : IOrderOptions
{
    
    private readonly OrderVolumeBuilder _orderVolumeBuilder = new();
    private readonly MoneyOptionsBuilder _moneyOptionsBuilder = new();

    public OrderType OrderType { get; private set; }
    public IOrderVolume Volume { get; private set; }
    public IMoneyOptions Price { get; private set; }
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
        _orderVolumeBuilder.WithValue(value);
        Volume = _orderVolumeBuilder;
        return this;
    }

    public OrderBuilder WithPrice(decimal value)
    {
        _moneyOptionsBuilder.WithValue(value);
        Price = _moneyOptionsBuilder;
        return this;
    }

    public Order Build()
    {
        return new Order(this);
    }
}