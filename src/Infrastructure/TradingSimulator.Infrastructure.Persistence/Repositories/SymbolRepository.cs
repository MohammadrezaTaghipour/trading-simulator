using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Infrastructure.Persistence.Repositories;

//TODO: implement it
public class SymbolRepository : ISymbolRepository
{
    public Task<Symbol> GetBy(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Add(Symbol symbol, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}