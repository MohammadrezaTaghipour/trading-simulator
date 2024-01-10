using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Query.Sessions;

public interface ISessionQueryService: IQueryService
{
    Task<SessionQueryResponse> GetById(Guid id, CancellationToken token);
    Task<IReadOnlyCollection<SessionQueryResponse>> GetAll(CancellationToken token);
}