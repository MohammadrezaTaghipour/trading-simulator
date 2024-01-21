using TradingSimulator.Domain.Models.Sessions;

namespace TradingSimulator.Domain.Models.OrderBooks.V1.Args;

public class DefineOrderBookArg
{
    public OrderBookId Id => new(SymbolId, SessionId);
    public string Title { get; set; }
    public SessionId SessionId { get; set; }
    public Guid SymbolId { get; set; }
}