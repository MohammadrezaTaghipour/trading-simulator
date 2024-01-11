using OrderBookManagement.Domain.Models.OrderBooks;

namespace OrderBookManagement.Infrastructure.Persistence.Repositories;

public class OrderBookRepository : IOrderBookRepository
{
    public Task<OrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Add(OrderBook orderBook, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}