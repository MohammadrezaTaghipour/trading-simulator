namespace TradingSimulator.Domain.Models.Shared.Monies;

public interface IMoneyOptions
{
    decimal Value { get; }
    
    
    public static bool operator >(IMoneyOptions left, IMoneyOptions right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(IMoneyOptions left, IMoneyOptions right)
    {
        return left.Value < right.Value;
    }
    
    public static bool operator >=(IMoneyOptions left, IMoneyOptions right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(IMoneyOptions left, IMoneyOptions right)
    {
        return left.Value <= right.Value;
    }
    
    public static bool operator >=(IMoneyOptions left, int right)
    {
        return left.Value >= right;
    }

    public static bool operator <=(IMoneyOptions left, int right)
    {
        return left.Value <= right;
    }
}