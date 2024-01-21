using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Symbols;

public interface ISymbolRepository : IRepository
{
    Task<Symbol> GetBy(Guid id, CancellationToken cancellationToken);
    Task Add(Symbol symbolOptions, CancellationToken cancellationToken);
}