namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

public class OrderId(long id)
{
    public long Id { get; private set; } = id;
    
}