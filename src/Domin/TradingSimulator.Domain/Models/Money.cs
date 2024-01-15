using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models;

public class Money(decimal value) : ValueObject
{
    public decimal Value { get; private set; } = value;

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
        return new Money(left.Value - right.Value);
    }

    public static Money operator +(Money left, Money right)
    {
        return new Money(left.Value + right.Value);
    }
}