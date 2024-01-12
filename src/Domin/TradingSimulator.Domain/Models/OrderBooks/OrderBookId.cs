namespace TradingSimulator.Domain.Models.OrderBooks;

public class OrderBookId(string id)
{
    public string Id { get; private set; } = id;

    public static OrderBookId New() => new OrderBookId(Guid.NewGuid().ToString());
}