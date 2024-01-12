using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Traders;

public interface ITraderRepository : IRepository
{
    Task<Trader> GetBy(TraderId id, CancellationToken cancellationToken);
    Task Add(Trader trader, CancellationToken cancellationToken);
}