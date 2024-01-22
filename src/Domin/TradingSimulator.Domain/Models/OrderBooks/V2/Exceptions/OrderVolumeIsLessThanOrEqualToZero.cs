using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;

public class OrderVolumeIsLessThanOrEqualToZero: BusinessException
{
    public OrderVolumeIsLessThanOrEqualToZero() : base(OrderBookExceptionsErrorEnum.OrderBook_BR_1004)
    {
    }
}