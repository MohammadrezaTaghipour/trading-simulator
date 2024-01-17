namespace TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

public class OrderId(Guid id)
{
    public Guid Id { get; private set; } = id;
    
    public static OrderId New() => new OrderId(Guid.NewGuid());
}