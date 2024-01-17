using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class Order : Entity<OrderId>, IOrderOptions
{
    public Order(IOrderOptions options)
    {
        GuardAgainstInvalidPrice(options);
        GuardAgainstInvalidVolume(options);
        
        Id = options.Id;
        OrderType = options.OrderType;
        Volume = options.Volume;
        Price = options.Price;
        CreatedOn = options.CreatedOn;
    }

    private void GuardAgainstInvalidPrice(IOrderOptions options)
    {
        if (options.Price <= 0)
            throw new OrderPriceIsLessThanOrEqualToZero();
    }
    
    private void GuardAgainstInvalidVolume(IOrderOptions options)
    { 
        if (options.Volume <= 0)
            throw new OrderVolumeIsLessThanOrEqualToZero();
    }

    public OrderType OrderType { get; private set;}
    public OrderVolume Volume { get; private set;}
    public Money Price { get; private set;}
    public DateTime CreatedOn { get; private set;}
}