using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.Symbols;

public interface ISymbolRepository : IDomainRepository
{
    Task<Symbol> GetBy(SymbolId id, CancellationToken cancellationToken);
    Task Add(Symbol symbol, CancellationToken cancellationToken);
}