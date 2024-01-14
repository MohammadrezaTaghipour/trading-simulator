using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class OrderVolume(long value) : ValueObject
{
    public long Value { get; private set; } = value;
    
    
    public static bool operator >(OrderVolume left, OrderVolume right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(OrderVolume left, OrderVolume right)
    {
        return left.Value < right.Value;
    }
    
    public static OrderVolume operator -(OrderVolume left, OrderVolume right)
    {
        return new OrderVolume(left.Value - right.Value);
    }
    
    public static OrderVolume operator +(OrderVolume left, OrderVolume right)
    {
        return new OrderVolume(left.Value + right.Value);
    }
}