using TradingSimulator.Domain.Models;
using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderOptionsTestBuilder : IOrderOptions
{
    public OrderOptionsTestBuilder()
    {
        Id = OrderId.New();
        OrderType = OrderType.Buy;
        Volume = new OrderVolume(100);
        Price = new Money(500);
    }
    
    public OrderId Id { get; private set; }
    public OrderType OrderType { get; private set; }
    public OrderVolume Volume { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedOn { get; private set; }
    

    public OrderOptionsTestBuilder WithId(Guid value)
    {
        Id = new OrderId(value);
        return this;
    }
    
    public OrderOptionsTestBuilder WithOrderType(OrderType value)
    {
        OrderType = value;
        return this;
    }
    
    public OrderOptionsTestBuilder WithVolume(OrderVolume value)
    {
        Volume = value;
        return this;
    }
    
    public OrderOptionsTestBuilder WithPrice(decimal value)
    {
        Price = new Money(value);
        return this;
    }
    
    public OrderOptionsTestBuilder Build()
    {
        return this;
    }
}