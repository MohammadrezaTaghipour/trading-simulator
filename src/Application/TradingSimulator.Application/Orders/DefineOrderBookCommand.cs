namespace TradingSimulator.Application.Orders;

public class DefineOrderBookCommand
{
    public string Title { get; set; }
    public Guid SessionId { get; set; }
    public Guid SymbolId { get; set; }
}

public class OrderBookCommandResult
{
    public string OrderBookId { get; set; }
}