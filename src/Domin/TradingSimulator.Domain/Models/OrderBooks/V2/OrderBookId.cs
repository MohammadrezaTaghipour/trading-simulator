using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBookId : ValueObject
{
    public OrderBookId(Guid symbolId)
    {
        SymbolId = symbolId;
    }

    public OrderBookId(string id)
    {
        if (!Guid.TryParse(id, out var item))
            throw new ArgumentException($"OrderBookId '{id}' is wrong.");

        SymbolId = Guid.Parse(id);
    }

    public string Id => $"{SymbolId}";
    public Guid SymbolId { get; private set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as OrderBookId);
    }
    
}