using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V1;

public interface IOrderBookRepository : IRepository
{
    Task<IOrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken);
    Task Add(IOrderBook orderBook, CancellationToken cancellationToken);
}