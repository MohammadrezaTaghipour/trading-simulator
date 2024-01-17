using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;

public class OrderPriceIsLessThanOrEqualToZero: BusinessException
{
    public OrderPriceIsLessThanOrEqualToZero() : base(OrderBookExceptionsErrorEnum.OrderBook_BR_1003)
    {
    }
}