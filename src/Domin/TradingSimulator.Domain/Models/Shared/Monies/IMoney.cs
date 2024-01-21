namespace TradingSimulator.Domain.Models.Shared.Monies;

public interface IMoney
{
    decimal Value { get; }
    
    
    public static bool operator >(IMoney left, IMoney right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(IMoney left, IMoney right)
    {
        return left.Value < right.Value;
    }
    
    public static bool operator >=(IMoney left, IMoney right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(IMoney left, IMoney right)
    {
        return left.Value <= right.Value;
    }
    
    public static bool operator >=(IMoney left, int right)
    {
        return left.Value >= right;
    }

    public static bool operator <=(IMoney left, int right)
    {
        return left.Value <= right;
    }
}