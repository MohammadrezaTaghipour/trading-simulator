using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;

public class OrderBookSymbolIdIsRequired : BusinessException
{
    public OrderBookSymbolIdIsRequired() : base(OrderBookExceptionsErrorEnum.OrderBook_BR_1002)
    {
    }
}