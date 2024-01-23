using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Shared.Monies;
using TradingSimulator.Domain.Models.Traders;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Args;

public class PlaceOrderArg
{
    public OrderId OrderId { get; set; }
    public OrderBookId OrderBookId { get; set; }
    public TraderId TraderId { get; set; }
    public SessionId SessionId { get; set; }
    public Guid SymbolId { get; set; }
    public OrderType Cmd { get; set; }
    public OrderVolume Volume { get; set; }
    public Shared.Monies.Money Price { get; set; }
}