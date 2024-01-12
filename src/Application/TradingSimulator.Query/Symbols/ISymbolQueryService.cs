using TradingSimulator.Infrastructure.Application;

namespace TradingSimulator.Query.Symbols;

public interface ISymbolQueryService : IQueryService
{
    Task<SymbolQueryResponse> GetById(Guid id, CancellationToken token);
    Task<IReadOnlyCollection<SymbolQueryResponse>> GetAll(CancellationToken token);
}