using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Query.Symbols;

public interface ISymbolQueryService : IQueryService
{
    Task<SymbolQueryResponse> GetById(Guid id, CancellationToken token);
    Task<IReadOnlyCollection<SymbolQueryResponse>> GetAll(CancellationToken token);
}