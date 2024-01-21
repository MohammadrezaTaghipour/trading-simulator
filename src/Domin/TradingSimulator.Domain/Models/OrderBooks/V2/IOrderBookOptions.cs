using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public interface IOrderBookOptions 
{
    string Title { get; }
    Guid SymbolId { get; }
    
    IReadOnlyCollection<IOrderOptions> Orders { get; }
}