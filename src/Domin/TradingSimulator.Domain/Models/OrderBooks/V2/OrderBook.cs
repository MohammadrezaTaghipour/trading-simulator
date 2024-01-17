using TradingSimulator.Domain.Models.OrderBooks.V2.Exceptions;
using TradingSimulator.Domain.Models.OrderBooks.V2.Options;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Domain.Models.OrderBooks.V2;

public class OrderBook : IOrderBook
{
    private OrderBook()
    {
    }

    public OrderBook(IOrderBookOptions options)
    {
        GuardAgainstEmptyTitle(options);
        GuardAgainstEmptySymbolId(options);
        
        Title = options.Title;
        SymbolId = options.SymbolId;
    }

    private void GuardAgainstEmptyTitle(IOrderBookOptions options)
    {
        if (string.IsNullOrEmpty(options.Title))
            throw new OrderBookTitleIsRequired();
    }
    
    private void GuardAgainstEmptySymbolId(IOrderBookOptions options)
    {
        if (Guid.Empty.Equals(options.SymbolId.Id))
            throw new OrderBookSymbolIdIsRequired();
    }

    public string Title { get; private set; }
    public SymbolId SymbolId { get; private set; }
}