using TradingSimulator.Domain.Models.Shared.OrderVolumes;

namespace TradingSimulator.Test.Domain.OrderVolumes;

public class OrderVolumeOptionsTestBuilder : IOrderVolumeOptions
{
    public OrderVolumeOptionsTestBuilder()
    {
        _sutBuilder.WithValue(100);
    }


    private readonly OrderVolumeBuilder _sutBuilder = new();
    public int Value => _sutBuilder.Value;

    public OrderVolumeOptionsTestBuilder WithValue(int value)
    {
        _sutBuilder.WithValue(value);
        return this;
    }

    public OrderVolume Build()
    {
        return new OrderVolume(this);
    }
}