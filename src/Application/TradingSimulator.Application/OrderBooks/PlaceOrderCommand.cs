namespace TradingSimulator.Application.OrderBooks;

public class PlaceOrderCommand
{
    public string OrderBookId { get; set; } 
    public Guid TraderId { get; set; }
    public Guid SessionId { get; set; }
    public Guid SymbolId { get; set; }
    public string Cmd { get; set; }
    public int Volume { get; set; }
    public decimal Price { get; set; }
}