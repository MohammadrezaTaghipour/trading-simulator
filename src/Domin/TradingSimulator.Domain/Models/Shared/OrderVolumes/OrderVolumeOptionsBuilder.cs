namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public class OrderVolumeOptionsBuilder : IOrderVolumeOptions
{
    public int Value { get; private set; }

    public OrderVolumeOptionsBuilder WithValue(int value)
    {
        Value = value;
        return this;
    }
    
    public OrderVolume Build()
    {
        return new OrderVolume(this);
    }
}