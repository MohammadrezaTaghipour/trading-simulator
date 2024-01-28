using TradingSimulator.Domain.Models.Shared.Monies.Exceptions;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Shared.Monies;

public class Money : ValueObject<Money>, IMoney
{
    internal Money(IMoney money)
    {
        if (money.Value <= 0)
            throw new MoneyCanNotInitializedWithLessThanZero();
        
        Value = money.Value;
    }

    public decimal Value { get; private set; }
    

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    

    // public static bool operator >(Money left, Money right)
    // {
    //     return left.Value > right.Value;
    // }
    //
    // public static bool operator <(Money left, Money right)
    // {
    //     return left.Value < right.Value;
    // }
    //
    // public static bool operator >=(Money left, Money right)
    // {
    //     return left.Value >= right.Value;
    // }
    //
    // public static bool operator <=(Money left, Money right)
    // {
    //     return left.Value <= right.Value;
    // }
}