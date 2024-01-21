namespace TradingSimulator.Domain.Models.Shared.OrderVolumes;

public interface IOrderVolume
{
    int Value { get; }
    
    
    public static bool operator >(IOrderVolume left, IOrderVolume right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(IOrderVolume left, IOrderVolume right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >=(IOrderVolume left, IOrderVolume right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(IOrderVolume left, IOrderVolume right)
    {
        return left.Value <= right.Value;
    }
    
    public static bool operator >=(IOrderVolume left, int right)
    {
        return left.Value >= right;
    }

    public static bool operator <=(IOrderVolume left, int right)
    {
        return left.Value <= right;
    }
}