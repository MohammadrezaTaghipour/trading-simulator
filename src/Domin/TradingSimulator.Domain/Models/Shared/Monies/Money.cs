using TradingSimulator.Domain.Models.Shared.Monies.Exceptions;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Shared.Monies;

public class Money : ValueObject, IMoney
{
    internal Money(IMoney money)
    {
        if (money.Value <= 0)
            throw new MoneyCanNotInitializedWithLessThanZero();
        
        Value = money.Value;
    }

    public decimal Value { get; private set; }
    
    protected bool Equals(Money other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Money)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    
    public static bool operator ==(Money left, Money right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(Money left, Money right)
    {
        return !(left == right);
    }

    public static bool operator >(Money left, Money right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(Money left, Money right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >=(Money left, Money right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(Money left, Money right)
    {
        return left.Value <= right.Value;
    }

    public static Money operator -(Money left, Money right)
    {
        left.Value -= right.Value;
        return left;
    }
    
    public static Money operator +(Money left, Money right)
    {
        left.Value += right.Value;
        return left;
    }
}