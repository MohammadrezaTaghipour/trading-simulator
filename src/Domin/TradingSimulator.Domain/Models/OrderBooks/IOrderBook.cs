using TradingSimulator.Domain.Models.OrderBooks.Args;
using TradingSimulator.Infrastructure.Utils;

namespace TradingSimulator.Domain.Models.OrderBooks;

public interface IOrderBook
{
    void PlaceOrder(PlaceOrderArg arg, IDateTimeProvider dateTimeProvider);
}