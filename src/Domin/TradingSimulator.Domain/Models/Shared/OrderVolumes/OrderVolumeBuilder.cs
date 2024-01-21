namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public class OrderVolumeBuilder : IOrderVolume
{
    public int Value { get; private set; }

    public OrderVolumeBuilder WithValue(int value)
    {
        Value = value;
        return this;
    }
    
    public OrderVolume Build()
    {
        return new OrderVolume(this);
    }
}