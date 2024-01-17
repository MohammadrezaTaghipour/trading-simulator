using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;

public class OrderBookTitleIsRequired : BusinessException
{
    public OrderBookTitleIsRequired() : base(OrderBookExceptionsErrorEnum.OrderBook_BR_1001)
    {
    }
}