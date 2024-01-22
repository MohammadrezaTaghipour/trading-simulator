using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderTestBuilder : IOrderOptions
{
    private readonly OrderBuilder _sutBuilder = new();
    
    public OrderTestBuilder()
    {
        _sutBuilder.WithOrderType( OrderType.Buy);
        _sutBuilder.WithVolume( 100); 
        _sutBuilder.WithPrice(500);
    }

    public OrderType OrderType => _sutBuilder.OrderType;
    public IOrderVolume Volume => _sutBuilder.Volume;
    public IMoneyOptions Price  => _sutBuilder.Price;
    public DateTime CreatedOn => _sutBuilder.CreatedOn;

    
    public OrderTestBuilder WithOrderType(OrderType value)
    {
        _sutBuilder.WithOrderType(value);
        return this;
    }

    public OrderTestBuilder WithVolume(int value)
    {
        _sutBuilder.WithVolume(value);
        return this;
    }

    public OrderTestBuilder WithPrice(decimal value)
    {
        _sutBuilder.WithPrice(value);
        return this;
    }

    public IOrder Build()
    {
        return _sutBuilder.Build();
    }
}