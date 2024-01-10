using OrderBookManagement.Domain.Models.Symbols;

namespace OrderBookManagement.Infrastructure.Persistence.Repositories;

//TODO: implement it
public class SymbolRepository : ISymbolRepository
{
    public Task<Symbol> GetBy(SymbolId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Add(Symbol symbol, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}