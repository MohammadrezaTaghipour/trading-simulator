using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBookId : ValueObject
{
    public OrderBookId(Guid symbolId)
    {
        SymbolId = symbolId;
    }

    public string Id => $"{SymbolId}";
    public Guid SymbolId { get; private set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as OrderBookId);
    }
    
}