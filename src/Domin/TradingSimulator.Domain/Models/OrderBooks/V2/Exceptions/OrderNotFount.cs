using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;

public class OrderNotFount : BusinessException
{
    public OrderNotFount(object id) : base(OrderBookExceptionsErrorEnum.OrderBook_BR_1005, id.ToString()!)
    {
    }
}