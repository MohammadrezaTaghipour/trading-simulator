using OrderBookManagement.Domain.Models.Sessions;
using OrderBookManagement.Domain.Models.Symbols;
using OrderBookManagement.Domain.Models.Traders;

namespace OrderBookManagement.Domain.Models.OrderBooks.Args;

public class PlaceOrderArg
{
    public TraderId TraderId { get; set; }
    public SessionId SessionId { get; set; }
    public SymbolId SymbolId { get; set; }
    public OrderCommandType Cmd { get; set; }
    public int Volume { get; set; }
    public decimal Price { get; set; }
}