using TradingSimulator.Domain.Models.OrderBooks.V2.Options;
using TradingSimulator.Domain.Models.Symbols;

namespace TradingSimulator.Test.Domain.OrderBooks.V2.Fixtures;

public class OrderBookOptionsTestBuilder : IOrderBookOptions
{
    public OrderBookOptionsTestBuilder()
    {
        Title = "Some order-book";
        SymbolId = SymbolId.New();
    }

    public string Title { get; private set; }
    public SymbolId SymbolId { get; private set; }


    public OrderBookOptionsTestBuilder WithTitle(string value)
    {
        Title = value;
        return this;
    }

    public OrderBookOptionsTestBuilder WithSymbolId(Guid value)
    {
        SymbolId = new SymbolId(value);
        return this;
    }

    public IOrderBookOptions Build()
    {
        return this;
    }
}