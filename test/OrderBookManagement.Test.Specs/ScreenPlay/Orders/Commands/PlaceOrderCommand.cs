namespace OrderBookManagement.Test.Specs.ScreenPlay.Orders.Commands;

public class PlaceOrderCommand
{
    public long Id { get; set; }
    public Guid TraderId { get; set; }
    public Guid SessionId { get; set; }
    public Guid SymbolId { get; set; }
    public string Cmd { get; set; }
    public int Volume { get; set; }
    public decimal Price { get; set; }
}