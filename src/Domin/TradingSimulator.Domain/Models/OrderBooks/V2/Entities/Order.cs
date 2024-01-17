using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class Order : Entity<OrderId>, IOrderOptions
{
    public Order(IOrderOptions options)
    {
        Id = options.Id;
        OrderType = options.OrderType;
        Volume = options.Volume;
        Price = options.Price;
        CreatedOn = options.CreatedOn;
    }
    
    public OrderType OrderType { get; private set;}
    public OrderVolume Volume { get; private set;}
    public Money Price { get; private set;}
    public DateTime CreatedOn { get; private set;}
}