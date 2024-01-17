namespace TradingSimulator.Domain.Models.OrderBooks.V1.Orders;

[Flags]
public enum OrderStateEnum
{
    Pending = 0,
    Matched = 1,
    Closed = 2
}