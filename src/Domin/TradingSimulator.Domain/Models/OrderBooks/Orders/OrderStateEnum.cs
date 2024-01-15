namespace TradingSimulator.Domain.Models.OrderBooks.Orders;

[Flags]
public enum OrderStateEnum
{
    Pending = 0,
    Matched = 1,
    Closed = 2
}