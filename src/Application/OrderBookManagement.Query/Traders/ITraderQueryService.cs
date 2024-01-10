using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Query.Traders;

public interface ITraderQueryService: IQueryService
{
    Task<TraderQueryResponse> GetById(Guid id, CancellationToken token);
    Task<IReadOnlyCollection<TraderQueryResponse>> GetAll(CancellationToken token);
}