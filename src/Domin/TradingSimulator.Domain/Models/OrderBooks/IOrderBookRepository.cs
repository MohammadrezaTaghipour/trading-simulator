using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks;

public interface IOrderBookRepository: IRepository
{
    Task<OrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken);
    Task Add(OrderBook orderBook, CancellationToken cancellationToken);
}