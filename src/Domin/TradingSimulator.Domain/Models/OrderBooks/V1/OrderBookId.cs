using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V1;

public class OrderBookId : IValueObject
{
    public OrderBookId(Guid symbolId, SessionId sessionId)
    {
        SymbolId = symbolId;
        SessionId = sessionId;
    }

    public OrderBookId(string id)
    {
        var compoundedId = id.Split('-');

        if (compoundedId.Count() != 2)
            throw new ArgumentException($"OrderBookId '{id}' is wrong.");

        Array.ForEach(compoundedId, idPart =>
        {
            if (!Guid.TryParse(idPart, out var item))
                throw new ArgumentException($"OrderBookId '{id}' is wrong.");
        });

        SymbolId = Guid.Parse(compoundedId[0]);
        SessionId = new SessionId(Guid.Parse(compoundedId[1]));
    }

    public string Id => $"{SymbolId}-{SessionId.Id}";
    public Guid SymbolId { get; private set; }
    public SessionId SessionId { get; private set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as OrderBookId);
    }

    protected bool Equals(OrderBookId other)
    {
        return SymbolId.Equals(other.SymbolId) && SessionId.Equals(other.SessionId);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SymbolId, SessionId);
    }
}