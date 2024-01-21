using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class Order : IOrder 
{
    internal Order(IOrderOptions options)
    {
        Id = OrderId.New();
        OrderType = options.OrderType;
        Volume = options.Volume;
        Price = options.Price;
        CreatedOn = options.CreatedOn;
    }

    public OrderId Id { get; private set; }
    public OrderType OrderType { get; private set; }
    public IOrderVolume Volume { get; private set; }
    public IMoney Price { get; private set; }
    public DateTime CreatedOn { get; private set; } 
}