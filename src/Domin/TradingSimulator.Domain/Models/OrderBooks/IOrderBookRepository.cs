using TradingSimulator.Domain.Models.OrderBooks.V2;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks;

public interface IOrderBookRepository: IRepository
{
    Task<IOrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken);
    Task Add(IOrderBook orderBook, CancellationToken cancellationToken);
}