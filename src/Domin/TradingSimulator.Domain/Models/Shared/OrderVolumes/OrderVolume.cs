using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public class OrderVolume : ValueObject<OrderVolume>, IOrderVolume
{
    internal OrderVolume(IOrderVolume volume)
    {
        Value = volume.Value;
    }

    public int Value { get; private set; }
    
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}