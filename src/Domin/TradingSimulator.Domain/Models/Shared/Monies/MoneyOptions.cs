using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Shared.Monies;

public class MoneyOptions : ValueObject, IMoneyOptions
{
    internal MoneyOptions(IMoneyOptions moneyOptions)
    {
        if (moneyOptions <= 0)
            throw new ArgumentOutOfRangeException($"MoneyOptions value: {moneyOptions.Value} is invalid.");
        
        Value = moneyOptions.Value;
    }

    public decimal Value { get; private set; }
    
    protected bool Equals(MoneyOptions other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MoneyOptions)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    
    public static bool operator ==(MoneyOptions left, MoneyOptions right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(MoneyOptions left, MoneyOptions right)
    {
        return !(left == right);
    }

    public static bool operator >(MoneyOptions left, MoneyOptions right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(MoneyOptions left, MoneyOptions right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >=(MoneyOptions left, MoneyOptions right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(MoneyOptions left, MoneyOptions right)
    {
        return left.Value <= right.Value;
    }

    public static bool operator >=(MoneyOptions left, int right)
    {
        return left.Value >= right;
    }

    public static bool operator <=(MoneyOptions left, int right)
    {
        return left.Value <= right;
    }

    public static MoneyOptions operator -(MoneyOptions left, MoneyOptions right)
    {
        left.Value -= right.Value;
        return left;
    }
    
    public static MoneyOptions operator +(MoneyOptions left, MoneyOptions right)
    {
        left.Value += right.Value;
        return left;
    }
}