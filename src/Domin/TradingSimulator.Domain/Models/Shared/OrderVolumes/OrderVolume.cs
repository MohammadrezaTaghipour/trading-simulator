using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public class OrderVolume : ValueObject, IOrderVolumeOptions
{
    public OrderVolume(IOrderVolumeOptions volumeOptions)
    {
        Value = volumeOptions.Value;
    }

    public int Value { get; private set; }


    protected bool Equals(IOrderVolumeOptions other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((IOrderVolumeOptions)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    
    public static bool operator ==(OrderVolume left, OrderVolume right)
    {
        return left.Value == right.Value;
    }
    
    public static bool operator !=(OrderVolume left, OrderVolume right)
    {
        return !(left == right);
    }
    
    public static bool operator >(OrderVolume left, OrderVolume right)
    {
        return left.Value > right.Value;
    }
    
    public static bool operator <(OrderVolume left, OrderVolume right)
    {
        return left.Value < right.Value;
    }
    
    public static bool operator >=(OrderVolume left, OrderVolume right)
    {
        return left.Value >= right.Value;
    }
    
    public static bool operator <=(OrderVolume left, OrderVolume right)
    {
        return left.Value <= right.Value;
    }
    
    public static OrderVolume operator -(OrderVolume left, OrderVolume right)
    {
        left.Value -= right.Value;
        return left;
    }
    
    public static OrderVolume operator +(OrderVolume left, OrderVolume right)
    {
        left.Value += right.Value;
        return left;
    }

    public static implicit operator int(OrderVolume volume) => volume.Value;
    public static implicit operator OrderVolume(int volume) =>
        new OrderVolumeOptionsBuilder().WithValue(volume).Build();
}