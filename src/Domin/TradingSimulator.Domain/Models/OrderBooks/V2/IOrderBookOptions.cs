using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public interface IOrderBookOptions
{
    string Title { get; }
    SymbolId SymbolId { get; }
}