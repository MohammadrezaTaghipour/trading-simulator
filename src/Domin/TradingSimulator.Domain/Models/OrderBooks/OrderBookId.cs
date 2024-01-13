using TradingSimulator.Domain.Models.Sessions;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks;

public class OrderBookId
{
    public OrderBookId(SymbolId symbolId, SessionId sessionId)
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

        SymbolId = new SymbolId(Guid.Parse(compoundedId[0]));
        SessionId = new SessionId(Guid.Parse(compoundedId[1]));
    }

    public string Id => $"{SymbolId.Id}-{SessionId.Id}";
    public SymbolId SymbolId { get; private set; }
    public SessionId SessionId { get; private set; }
}