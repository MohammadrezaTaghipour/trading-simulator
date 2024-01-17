using TradingSimulator.Domain.Models.OrderBooks.V1.Orders;
using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Args;

public class PlaceOrderArg
{
    public OrderId OrderId { get; set; }
    public OrderBookId OrderBookId { get; set; }
    public TraderId TraderId { get; set; }
    public SessionId SessionId { get; set; }
    public SymbolId SymbolId { get; set; }
    public OrderType Cmd { get; set; }
    public OrderVolume Volume { get; set; }
    public Money Price { get; set; }
}