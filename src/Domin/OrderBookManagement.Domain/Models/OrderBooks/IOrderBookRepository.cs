using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.OrderBooks;

public interface IOrderBookRepository: IDomainRepository
{
    Task<OrderBook> GetBy(OrderBookId id, CancellationToken cancellationToken);
    Task Add(OrderBook orderBook, CancellationToken cancellationToken);
}