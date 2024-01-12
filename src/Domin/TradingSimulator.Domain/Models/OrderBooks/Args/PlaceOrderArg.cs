using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;
using TradingSimulator.Domain.Models.Traders;

namespace TradingSimulator.Domain.Models.OrderBooks.Args;

public class PlaceOrderArg
{
    public TraderId TraderId { get; set; }
    public SessionId SessionId { get; set; }
    public SymbolId SymbolId { get; set; }
    public OrderCommandType Cmd { get; set; }
    public int Volume { get; set; }
    public decimal Price { get; set; }
}