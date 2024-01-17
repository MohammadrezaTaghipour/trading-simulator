using TradingSimulator.Domain.Models.OrderBooks.V1.Args;
using TradingSimulator.Infrastructure.Utils;

namespace TradingSimulator.Domain.Models.OrderBooks.V1;

public interface IOrderBook
{
    void PlaceOrder(PlaceOrderArg arg, IDateTimeProvider dateTimeProvider);
}