using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public class Order : IOrder
{
    internal Order(IOrderOptions options)
    {
        Id = OrderId.New();
        OrderType = options.OrderType;
        Volume = new OrderVolume(options.Volume);
        _price = new Money(options.Price);
        CreatedOn = options.CreatedOn;
        _matchedVolume = new OrderVolume(options.Volume - options.Volume); // init it by zero
        IsCanceled = false;
    }

    public OrderId Id { get; private set; }
    public OrderType OrderType { get; private set; }

    private OrderVolume _matchedVolume;

    private OrderVolume Volume { get; set; }
    IOrderVolume IOrderOptions.Volume => Volume;

    private readonly Money _price;
    public IMoney Price => _price;

    public DateTime CreatedOn { get; private set; }
    public bool IsCanceled { get; private set; }

    public bool CanBeMatchedWith(IOrder order)
    {
        if (order.OrderType is OrderType.Buy)
            return _price.Value <= order.Price.Value;
        return _price.Value >= order.Price.Value;
    }

    public bool IsCompletelyMatched()
    {
        return Volume.Value == _matchedVolume.Value;
    }

    public void IncreaseMatchedVolume(int volume)
    {
        _matchedVolume = (new OrderVolumeBuilder().WithValue(volume).Build() as OrderVolume)!;
    }

    public void SetAsCanceled()
    {
        IsCanceled = true;
    }
}