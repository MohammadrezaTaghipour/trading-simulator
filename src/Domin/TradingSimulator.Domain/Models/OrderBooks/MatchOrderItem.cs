using TradingSimulator.Domain.Models.OrderBooks.Orders;

namespace TradingSimulator.Domain.Models.OrderBooks;

public class MatchOrderItem
{
    public MatchOrderItem(OrderId orderId, OrderBookId orderBookId,
        int volume, decimal price, DateTime createdOn)
    {
        OrderId = orderId;
        OrderBookId = orderBookId;
        Volume = volume;
        Price = price;
        CreatedOn = createdOn;
    }

    public OrderId OrderId { get; }
    public OrderBookId OrderBookId { get; }
    public int Volume { get; }
    public decimal Price { get; }
    public DateTime CreatedOn { get; }
}