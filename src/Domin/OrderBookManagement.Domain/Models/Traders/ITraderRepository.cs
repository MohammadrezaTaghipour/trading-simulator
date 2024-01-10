using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.Traders;

public interface ITraderRepository : IDomainRepository
{
    Task<Trader> GetBy(TraderId id, CancellationToken cancellationToken);
    Task Add(Trader trader, CancellationToken cancellationToken);
}