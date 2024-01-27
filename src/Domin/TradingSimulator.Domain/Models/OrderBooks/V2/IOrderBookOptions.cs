using TradingSimulator.Domain.Models.OrderBooks.V2.Orders;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public interface IOrderBookOptions 
{
    string Title { get; }
    Guid SymbolId { get; }
    
    IReadOnlyList<IOrderOptions> Orders { get; }
}