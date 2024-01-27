namespace TradingSimulator.Application.OrderBooks.V2.Commands;

public class DequeueOrderCommand
{
    public Guid SymbolId { get; set; }
    public Guid OrderId { get; set; }
}