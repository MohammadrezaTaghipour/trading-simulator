namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public class OrderVolumeBuilder : IOrderVolume
{
    public int Value { get; private set; }

    public OrderVolumeBuilder WithValue(int value)
    {
        Value = value;
        return this;
    }
    
    public IOrderVolume Build()
    {
        return new OrderVolume(this);
    }
}