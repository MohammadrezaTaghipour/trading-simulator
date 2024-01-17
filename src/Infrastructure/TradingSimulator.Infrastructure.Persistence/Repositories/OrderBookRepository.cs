using TradingSimulator.Domain.Models.OrderBooks;
using TradingSimulator.Domain.Models.OrderBooks.V1;

namespace TradingSimulator.Infrastructure.Persistence.Repositories;

public class OrderBookRepository : IOrderBookRepository
{
    public Task<IOrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Add(IOrderBook orderBook, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}