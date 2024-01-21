using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderTestBuilder : IOrderOptions
{
    private readonly OrderBuilder _sutBuilder = new();
    
    public OrderTestBuilder()
    {
        OrderType = OrderType.Buy;
        Volume = _sutBuilder.Volume; 
        Price = _sutBuilder.Price;
        CreatedOn = DateTime.Now;
    }

    public OrderType OrderType { get; private set;}
    public IOrderVolume Volume { get; private set;}
    public IMoney Price { get; private set;}
    public DateTime CreatedOn { get; private set;}

    
    public OrderTestBuilder WithOrderType(OrderType value)
    {
        OrderType = value;
        return this;
    }

    public OrderTestBuilder WithVolume(int value)
    {
        _sutBuilder.WithVolume(value);
        Volume = _sutBuilder.Volume;
        return this;
    }

    public OrderTestBuilder WithPrice(decimal value)
    {
        _sutBuilder.WithPrice(value);
        Price = _sutBuilder.Price;
        return this;
    }

    public Order Build()
    {
        return _sutBuilder.Build();
    }
}