using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.Symbols;

public interface ISymbolRepository : IRepository
{
    Task<Symbol> GetBy(SymbolId id, CancellationToken cancellationToken);
    Task Add(Symbol symbol, CancellationToken cancellationToken);
}