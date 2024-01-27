namespace TradingSimulator.Application.OrderBooks.V2.Commands;

public class EnqueueOrderCommand
{
    public Guid SymbolId { get; set; }
    public string CommandType { get; set; }
    public int Volume { get; set; }
    public decimal Price { get; set; }
}