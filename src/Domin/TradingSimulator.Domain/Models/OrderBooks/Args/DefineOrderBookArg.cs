using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks.Args;

public class DefineOrderBookArg
{
    public OrderBookId Id => new(SymbolId, SessionId);
    public string Title { get; set; }
    public SessionId SessionId { get; set; }
    public SymbolId SymbolId { get; set; }
}