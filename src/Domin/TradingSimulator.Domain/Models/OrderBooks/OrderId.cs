namespace TradingSimulator.Domain.Models.OrderBooks;

public class OrderId(long id)
{
    public long Id { get; private set; } = id;
    
}