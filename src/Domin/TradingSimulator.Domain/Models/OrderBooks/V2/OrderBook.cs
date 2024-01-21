using TradingSimulator.Domain.Models.OrderBooks.V2.Entities;
using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBook : AggregateRoot<OrderBookId>, IOrderBook
{
    public string Title { get; private set; }
    public Guid SymbolId { get; private set; }

    private List<IOrderOptions> _orders = new();
    IReadOnlyCollection<IOrderOptions> IOrderBook.Orders => _orders;
    IReadOnlyCollection<IOrderOptions> IOrderBookOptions.Orders => _orders;
    

    internal OrderBook(IOrderBookOptions options)
    {
        GuardAgainstEmptyTitle(options);
        GuardAgainstEmptySymbolId(options);

        Id = new OrderBookId(options.SymbolId);
        Title = options.Title;
        SymbolId = options.SymbolId;
    }

    public void EnqueueOrder(IOrderOptions options)
    {
        _orders.Add(new Order(options));
    }

    private void GuardAgainstEmptyTitle(IOrderBookOptions options)
    {
        if (string.IsNullOrEmpty(options.Title))
            throw new OrderBookTitleIsRequired();
    }

    private void GuardAgainstEmptySymbolId(IOrderBookOptions options)
    {
        if (Guid.Empty.Equals(options.SymbolId))
            throw new OrderBookSymbolIdIsRequired();
    }
}