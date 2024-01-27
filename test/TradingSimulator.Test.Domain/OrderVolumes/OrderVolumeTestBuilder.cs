using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Test.Domain.OrderVolumes;

public class OrderVolumeTestBuilder : IOrderVolume
{
    public OrderVolumeTestBuilder()
    {
        _sutBuilder.WithValue(100);
    }


    private readonly OrderVolumeBuilder _sutBuilder = new();
    public int Value => _sutBuilder.Value;

    public OrderVolumeTestBuilder WithValue(int value)
    {
        _sutBuilder.WithValue(value);
        return this;
    }

    public OrderVolume Build()
    {
        return new OrderVolume(this);
    }
}