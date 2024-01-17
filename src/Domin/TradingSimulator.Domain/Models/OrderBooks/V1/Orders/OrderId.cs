namespace TradingSimulator.Domain.Models.OrderBooks.V1.Orders;

public class OrderId(Guid id)
{
    public Guid Id { get; private set; } = id;
    
    public static OrderId New() => new OrderId(Guid.NewGuid());
}