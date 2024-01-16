using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class OrderVolume(int value) : ValueObject
{
    public int Value { get; private set; } = value;


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
        return new OrderVolume(left.Value - right.Value);
    }

    public static OrderVolume operator +(OrderVolume left, OrderVolume right)
    {
        return new OrderVolume(left.Value + right.Value);
    }

    public static OrderVolume operator -(OrderVolume left, int right)
    {
        return new OrderVolume(left.Value - right);
    }

    public static OrderVolume operator +(OrderVolume left, int right)
    {
        return new OrderVolume(left.Value + right);
    }

    public static implicit operator int(OrderVolume volume) => volume.Value;
    public static implicit operator OrderVolume(int volume) =>new OrderVolume(volume);
}