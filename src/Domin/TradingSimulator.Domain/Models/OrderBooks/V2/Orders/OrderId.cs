namespace TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

public class OrderId(Guid id)
{
    public Guid Id { get; private set; } = id;
    
    public static OrderId New() => new OrderId(Guid.NewGuid());
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as OrderId);
    }

    protected bool Equals(OrderId other)
    {
        return id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(id);
    }
}